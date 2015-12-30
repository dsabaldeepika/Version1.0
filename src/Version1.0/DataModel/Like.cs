namespace Version1.DataModel
{
    public class Like :Edit
    {
        public int Id { get; set; }
        public string To { get; set; }
        public int ToId { get; set; }
        public string By { get; set; }
        public int ById { get; set; }
        public string CommentContent { get; set; }

        public string StatusId { get; set; }

    }
}