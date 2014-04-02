using System;
using System.Collections.Generic;
using System.Linq;

namespace GXService.GameServer
{
    public class RoomFactory<T, TI>
        where T : RoomContext<TI>, new()
        where TI : class 
    {
        private readonly List<RoomContext<TI>> _roomContexts = new List<RoomContext<TI>>();

        public static RoomFactory<T, TI> Singleton = new RoomFactory<T, TI>();

        private RoomFactory()
        {}

        public RoomContext<TI> CreateRoom()
        {
            var c = typeof (T).GetConstructor(Type.EmptyTypes);
            if (c == null)
            {
                return null;
            }
            var roomContext = c.Invoke(null) as T;
            _roomContexts.Add(roomContext);

            return roomContext;
        }

        public RoomContext<TI> GetRoom(string roomId)
        {
            return _roomContexts.FirstOrDefault(r => r.RoomId == roomId);
        }

        public List<RoomContext<TI>> GetAllRoom()
        {
            return _roomContexts.ToList();
        }
    }
}
