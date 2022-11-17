using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HostelApi.Models;

namespace HostelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HostelDbContext _context;

        public UsersController(HostelDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            //List<UserViewModel> result = new List<UserViewModel>();
            //users.ForEach(async (user) =>
            //{
            //    Room room = new Room();
            //    try
            //    {
            //        room = await _context.Rooms.FindAsync(user.RoomRefId);
            //    }
            //    catch(Exception ex)
            //    {

            //    }
            //    UserViewModel userViewModel = new UserViewModel();
            //    userViewModel.ID = user.ID;
            //    userViewModel.Name = user.Name;
            //    userViewModel.Age = user.Age;
            //    userViewModel.DateOfJoining = user.DateOfJoining;
            //    userViewModel.TemporaryAddress = user.TemporaryAddress;
            //    userViewModel.contactNo = user.contactNo;
            //    userViewModel.PermanantAddress = user.PermanantAddress;
            //    userViewModel.Advance = user.Advance;
            //    userViewModel.WellWisher1Name = user.WellWisher1Name;
            //    userViewModel.WellWisher1Address = user.WellWisher1Address;
            //    userViewModel.WellWisher1Contact = user.WellWisher1Contact;
            //    userViewModel.WellWisher2Name = user.WellWisher2Name;
            //    userViewModel.WellWisher2Address = user.WellWisher2Address;
            //    userViewModel.WellWisher2Contact = user.WellWisher2Contact;
            //    userViewModel.photoUrl = user.photoUrl;
            //    userViewModel.IdProofUrl = user.IdProofUrl;
            //    userViewModel.DueDate = user.DueDate;
            //    userViewModel.room = room;
            //    result.Add(userViewModel);
            //});
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            
            await _context.SaveChangesAsync();
            await updateRoom(user.RoomRefId);
            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user.RoomRefId);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
        private async Task<bool> updateRoom(int roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);
            if (room == null)
            {
                return false;
            }
            else
            {
                if (room.Capacity > room.Filled)
                {
                    room.Filled = room.Filled+1;
                    _context.Entry(room).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
