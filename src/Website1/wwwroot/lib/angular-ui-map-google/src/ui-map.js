'use strict';
(function () {
  var app = angular.module('ui.map', ['ui.event']);

  //Setup map events from a google map object to trigger on a given element too,
  //then we just use ui-event to catch events from an element
  function bindMapEvents(scope, eventsStr, googleObject, element) {
    angular.forEach(eventsStr.split(' '), function (eventName) {
      //Prefix all googlemap events with 'map-', so eg 'click'
      //for the googlemap doesn't interfere with a normal 'click' event
      window.google.maps.event.addListener(googleObject, eventName, function (event) {
        element.triggerHandler('map-' + eventName, event);
        //We create an $apply if it isn't happening. we need better support for this
        //We don't want to use timeout because tons of these events fire at once,
        //and we only need one $apply
        if (!scope.$$phase){ scope.$apply();}
      });
    });
  }

  app.value('uiMapConfig', {}).directive('uiMap',
    ['uiMapConfig', '$parse', '$timeout', function (uiMapConfig, $parse, $timeout) {

      var mapEvents = 'bounds_changed center_changed click dblclick drag dragend ' +
        'dragstart heading_changed idle maptypeid_changed mousemove mouseout ' +
        'mouseover projection_changed resize rightclick tilesloaded tilt_changed ' +
        'zoom_changed';
      var options = uiMapConfig || {};

      return {
        restrict: 'A',
        //doesn't work as E for unknown reason
        link: function (scope, elm, attrs) {
            var map;
          var opts = angular.extend({}, options, scope.$eval(attrs.uiOptions));

            scope.$on("map.loaded", function(e, type) {
                if(type == "google" && !map) {
                    initMap();
                }
            });

            if(window.google&&window.google.maps&&window.google.maps.Map) {
                $timeout(function() {
                    initMap();
                }, 200);
            }
            function initMap() {
                if (opts.uiMapCache && window[attrs.uiMapCache]) {
                    elm.replaceWith(window[attrs.uiMapCache]);
                    map = window[attrs.uiMapCache+"Map"];
                } else {
                    if(opts.centerPoint&&opts.centerPoint.lat&&opts.centerPoint.lng) {
                        opts.center = new google.maps.LatLng(opts.centerPoint.lat, opts.centerPoint.lng);
                    }
                    map = new window.google.maps.Map(elm[0], opts);
                    var model = $parse(attrs.uiMap);

                    //Set scope variable for the map
                    model.assign(scope, map);

                    bindMapEvents(scope, mapEvents, map, elm);
                }
            }

        }
      };
    }]);

  app.value('uiMapInfoWindowConfig', {}).directive('uiMapInfoWindow',
    ['uiMapInfoWindowConfig', '$parse', '$compile', function (uiMapInfoWindowConfig, $parse, $compile) {

      var infoWindowEvents = 'closeclick content_change domready ' +
        'position_changed zindex_changed';
      var options = uiMapInfoWindowConfig || {};

      return {
        link: function (scope, elm, attrs) {
          var opts = angular.extend({}, options, scope.$eval(attrs.uiOptions));
          opts.content = elm[0];
          var model = $parse(attrs.uiMapInfoWindow);
          var infoWindow = model(scope);

            scope.$on("map.loaded", function(e, type) {
                if(type == "google" && !infoWindow) {
                    initInfoWindow();
                }
            });

            if(window.google&&window.google.maps&&window.google.maps.Map) {
                initInfoWindow();
            }

            function initInfoWindow() {
                if (!infoWindow) {
                    infoWindow = new window.google.maps.InfoWindow(opts);
                    model.assign(scope, infoWindow);
                }

                bindMapEvents(scope, infoWindowEvents, infoWindow, elm);

                /* The info window's contents dont' need to be on the dom anymore,
                 google maps has them stored.  So we just replace the infowindow element
                 with an empty div. (we don't just straight remove it from the dom because
                 straight removing things from the dom can mess up angular) */
                elm.replaceWith('<div></div>');

                //Decorate infoWindow.open to $compile contents before opening
                var _open = infoWindow.open;
                infoWindow.open = function open(a1, a2, a3, a4, a5, a6) {
                    $compile(elm.contents())(scope);
                    _open.call(infoWindow, a1, a2, a3, a4, a5, a6);
                };
            }
        }
      };
    }]);

  /*
   * Map overlay directives all work the same. Take map marker for example
   * <ui-map-marker="myMarker"> will $watch 'myMarker' and each time it changes,
   * it will hook up myMarker's events to the directive dom element.  Then
   * ui-event will be able to catch all of myMarker's events. Super simple.
   */
  function mapOverlayDirective(directiveName, events) {
    app.directive(directiveName, [function () {
      return {
        restrict: 'A',
        link: function (scope, elm, attrs) {
          scope.$watch(attrs[directiveName], function (newObject) {
            if (newObject) {
              bindMapEvents(scope, events, newObject, elm);
            }
          });
        }
      };
    }]);
  }

  mapOverlayDirective('uiMapMarker',
    'animation_changed click clickable_changed cursor_changed ' +
      'dblclick drag dragend draggable_changed dragstart flat_changed icon_changed ' +
      'mousedown mouseout mouseover mouseup position_changed rightclick ' +
      'shadow_changed shape_changed title_changed visible_changed zindex_changed');

  mapOverlayDirective('uiMapPolyline',
    'click dblclick mousedown mousemove mouseout mouseover mouseup rightclick');

  mapOverlayDirective('uiMapPolygon',
    'click dblclick mousedown mousemove mouseout mouseover mouseup rightclick');

  mapOverlayDirective('uiMapRectangle',
    'bounds_changed click dblclick mousedown mousemove mouseout mouseover ' +
      'mouseup rightclick');

  mapOverlayDirective('uiMapCircle',
    'center_changed click dblclick mousedown mousemove ' +
      'mouseout mouseover mouseup radius_changed rightclick');

  mapOverlayDirective('uiMapGroundOverlay',
    'click dblclick');

    app.provider('uiMapLoadParams', function uiMapLoadParams() {
        var params = {
            sensor: true
        };

        this.setParams = function(ps) {
            params = ps;
        };

        this.$get = function uiMapLoadParamsFactory() {
            return params;
        };
    })
        .directive('uiMapAsyncLoad', ['$window', '$parse', 'uiMapLoadParams',
            function ($window, $parse, uiMapLoadParams) {
                return {
                    restrict: 'A',
                    link: function (scope, element, attrs) {

                        $window.mapgoogleLoadedCallback = function mapgoogleLoadedCallback(){
                            scope.$broadcast("map.loaded", "google");
                        };

                        var params = angular.extend({}, uiMapLoadParams, scope.$eval(attrs.uiMapAsyncLoad));

                        params.callback = "mapgoogleLoadedCallback";

                        if(!($window.google&&$window.google.maps)) {
                            var script = document.createElement("script");
                            script.type = "text/javascript";
                            script.src = "http://maps.googleapis.com/maps/api/js?" + param(params);
                            document.body.appendChild(script);
                        }else {
                            mapgoogleLoadedCallback();
                        }
                    }
                }
            }]);

    /**
     * 序列化js对象
     *
     * @param a
     * @param traditional
     * @returns {string}
     */
    function param(a, traditional) {
        var prefix,
            s = [],
            add = function (key, value) {
                // If value is a function, invoke it and return its value
                value = angular.isFunction(value) ? value() : ( value == null ? "" : value );
                s[ s.length ] = encodeURIComponent(key) + "=" + encodeURIComponent(value);
            };

        // If an array was passed in, assume that it is an array of form elements.
        if (angular.isArray(a) || ( a.jquery && !angular.isObject(a) )) {
            // Serialize the form elements
            angular.forEach(a, function () {
                add(this.name, this.value);
            });

        } else {
            // If traditional, encode the "old" way (the way 1.3.2 or older
            // did it), otherwise encode params recursively.
            for (prefix in a) {
                buildParams(prefix, a[ prefix ], traditional, add);
            }
        }

        // Return the resulting serialization
        return s.join("&").replace(r20, "+");
    }

    var r20 = /%20/g;

    function buildParams(prefix, obj, traditional, add) {
        var name;

        if (angular.isArray(obj)) {
            // Serialize array item.
            angular.forEach(obj, function (v, i) {
                if (traditional || rbracket.test(prefix)) {
                    // Treat each array item as a scalar.
                    add(prefix, v);

                } else {
                    // Item is non-scalar (array or object), encode its numeric index.
                    buildParams(prefix + "[" + ( typeof v === "object" ? i : "" ) + "]", v, traditional, add);
                }
            });

        } else if (!traditional && angular.isObject(obj)) {
            // Serialize object item.
            for (name in obj) {
                buildParams(prefix + "[" + name + "]", obj[ name ], traditional, add);
            }

        } else {
            // Serialize scalar item.
            add(prefix, obj);
        }
    }

    var decode = decodeURIComponent;

})();
