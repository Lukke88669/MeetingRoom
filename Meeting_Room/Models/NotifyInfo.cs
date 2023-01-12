namespace Meeting_Room.Models
{
    public class NotifyInfo
    {
        public int Id { get; set; }

        public string UserId { get; set; } = "";

        // 通知內容
        public string InfoContext { get; set; } = string.Empty;

        // 是否已經通知
        public Boolean HaveNotify { get; set; }
    }
}
