using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Meeting_Room.Models
{
    public class Room
    {
        [Display(Name = "編號")]
        public int Id { get; set; }

        [Display(Name = "名稱")]
        public string Name { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "類型")]
        public string Type { get; set; }

        [Display(Name = "容納人數")]
        public int Capacity { get; set; }

        [Display(Name = "是否有投影機")]
        public Boolean HaveProjector { get; set; }

        [Display(Name = "是否有白板")]
        public Boolean HaveWhiteboard { get; set; }

        [Display(Name = "是否可使用")]
        public Boolean IsActive { get; set; }

        public Room() { }
    }
}
