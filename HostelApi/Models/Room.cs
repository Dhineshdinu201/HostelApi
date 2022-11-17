using HostelApi.Models;
namespace HostelApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Filled { get; set; }
    }
}
