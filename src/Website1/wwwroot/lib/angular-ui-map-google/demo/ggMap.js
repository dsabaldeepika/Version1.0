/**
 * Created by any on 2014/10/9.
 */
/* global console:false, google:false */
/*jshint unused:false */
'use strict';

function initCall() {
    console.log('Google maps api initialized.');
    angular.bootstrap(document.getElementById('map'), ['doc.ui-map']);
}

angular.module('doc.ui-map', ['ui.map'])
    .config(['uiMapLoadParamsProvider', function (uiMapLoadParamsProvider) {
        uiMapLoadParamsProvider.setParams({
            key:'AIzaSyA9e11ZRebw8fHsd1ZIi0FLTXsrSQTc490'// your map's develop key
        });
    }])
    .controller('MapCtrl', ['$scope', function ($scope) {

        $scope.myMarkers = [];

        $scope.mapOptions = {
            centerPoint: {lat: 35.784, lng: 116},
            zoom: 15
//            ,
//            mapTypeId: google.maps.MapTypeId.ROADMAP
        };

        $scope.addMarker = function ($event, $params) {
            $scope.myMarkers.push(new google.maps.Marker({
                map: $scope.myMap,
                position: $params[0].latLng
            }));
        };

        $scope.setZoomMessage = function (zoom) {
            $scope.zoomMessage = 'You just zoomed to ' + zoom + '!';
            console.log(zoom, 'zoomed');
        };

        $scope.openMarkerInfo = function (marker) {
            $scope.currentMarker = marker;
            $scope.currentMarkerLat = marker.getPosition().lat();
            $scope.currentMarkerLng = marker.getPosition().lng();
            $scope.myInfoWindow.open($scope.myMap, marker);
        };

        $scope.setMarkerPosition = function (marker, lat, lng) {
            marker.setPosition(new google.maps.LatLng(lat, lng));
        };
    }])
;