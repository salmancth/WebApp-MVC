using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class FeverCheckerModel
    {
        public float Temperature { get; set; }
        

		public static string Fever(float temperature)
		{
         
            if (temperature <= 34)
                return "  In hypothermia your heart, nervous system and other organs can't work normally. " + 
                    "Left untreated, hypothermia can lead to complete failure of your heart and respiratory system and eventually to death. " +
                    "Hypothermia is often caused by exposure to cold weather or immersion in cold water.Hypothermia is a medical emergency.";
            else if (temperature == 38)
                return "You have a fever ,Please take care yourself ";
            else if (temperature == 39)
                return "You have a fever ,Please take care yourself ";
            else if (temperature > 39)
                return "You have a High fever ,Please call for emergency help ";
            else
                return "You Are fine and healthy. Enjoy your life!";
        }
	}
}
