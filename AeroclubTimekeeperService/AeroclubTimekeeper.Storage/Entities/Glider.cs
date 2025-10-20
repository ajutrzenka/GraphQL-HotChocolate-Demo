namespace AeroclubTimekeeper.Storage.Entities
{
    public class Glider : Aircraft
    {
        public int LiftToDragRatio { get; set; }

        public int OptimalSpeed { get; set; }
    }
}
