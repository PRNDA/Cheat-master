using System.Collections.Generic;
using System.Linq;
using GXService.Broadcast.Service.Models;

namespace GXService.Broadcast.Service
{
    public class RoomFactory
    {
        private readonly List<RoomContext> _roomContexts = new List<RoomContext>();
 
        public static RoomFactory Singleton = new RoomFactory();

        private RoomFactory()
        {}

        public RoomContext CreateRoom()
        {
            var roomContext =  new RoomContext();
            _roomContexts.Add(roomContext);

            return roomContext;
        }

        public RoomContext GetRoom(string roomId)
        {
            return _roomContexts.FirstOrDefault(r => r.RoomId == roomId);
        }

        public List<RoomContext> GetAllRoom()
        {
            return _roomContexts.ToList();
        }
    }
}
