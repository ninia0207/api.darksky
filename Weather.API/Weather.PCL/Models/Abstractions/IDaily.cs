

namespace Weather.PCL.Models.Abstractions
{
    public interface IDaily
    {
        public string Summary { get; set; }
        public string Icon { get; set; }
    }
}
