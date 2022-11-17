using HostelApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostelApi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string DateOfJoining { get; set; }
        public string TemporaryAddress { get; set; }
        public string contactNo { get; set; }
        public string PermanantAddress { get; set; }
        public decimal Advance { get; set; }
        public string WellWisher1Name { get; set; }
        public string WellWisher1Address { get; set; }
        public string WellWisher1Contact { get; set; }
        public string? WellWisher2Name { get; set; }
        public string? WellWisher2Address { get; set; }
        public string? WellWisher2Contact { get; set; }
        public string photoUrl { get; set; }
        public string IdProofUrl { get; set; }
        [ForeignKey("Room")]
        public int RoomRefId { get; set; }
        public string DueDate { get; set; }
    }
    public class UserViewModel: User
    {
        public Room room { get; set; }
    }
}