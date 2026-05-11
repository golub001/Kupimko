using Backend.Models;

namespace Backend.DTO
{
    public class UpdateAdDto
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public int Price {  get; set; }
        public string Location {  get; set; }
    }
}
