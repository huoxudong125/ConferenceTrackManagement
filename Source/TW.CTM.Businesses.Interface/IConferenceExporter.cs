using TW.CTM.Models;

namespace TW.CTM.Businesses
{
    public interface IConferenceExporter
    {
        void Export(Conference conference);
    }
}