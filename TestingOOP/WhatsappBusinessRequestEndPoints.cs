using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOOP
{
    public class WhatsappBusinessRequestEndPoints
    {
        public Uri BasePath { get; private set; } = new Uri("https://graph.facebook.com/v17.0/");
        public string bearerToken { get; private set; } = "EAAJ8Wwc939sBOz3fLfvGBSMy4Rs2jyUXxZCwxHt5bqfaZChAW1nUjSir9ZA98a2V7ABiMSTZAycZAZCgQ9ZA6VXgqiprqT678VHTr5DPtPnoRZCyFav5o6kAjZBsX31DSMisEbWNKCbxb9WyMxyMmYo8768yIb4Rhh1iSDMfiK5LawvP9zlULUmSWEsNd7Kg2wdEi";
        public string BusinessProfileId { get; private set; } = "170773602786489";
        public  string BusinessNumberID { get; private set; } = "161313057070876";
        public string PostMessagePath { get; private set; } = "/messages";
        public string PostTemplatePath { get; private set; } = "/message_templates";
    }
}
