using CodeBase.Data;
using CodeBase.Gameplay.GarbageDetection;

namespace CodeBase.Extensions
{
    public static class GarbageDeathableExtension
    {
        public static GarbageDeathableData ToData(this GarbageDeathable garbageDeathable)
        {
          return  new GarbageDeathableData()
              .SetData(garbageDeathable.transform.position.ToData(), garbageDeathable.IsDead,
                garbageDeathable.Id);
        }
        
        public static GarbageDeathableData SetData(this GarbageDeathableData garbageDeathable, Vector3Data vector3Data, bool isDead,string id)
        {
            garbageDeathable.Vector3Data = vector3Data;
            garbageDeathable.Id = id;
            garbageDeathable.IsDead = isDead;
            return garbageDeathable;
        }
    }
}