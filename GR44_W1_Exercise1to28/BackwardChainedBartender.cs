using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28
{
    internal class AskGuestEventArg : EventArgs
    {
        public string Question { get; init; }
        public string Answer { get; set; } 
        //public string[]? ValidAnswers { get; init; }

        public AskGuestEventArg(string question) //, string[]? validAnswers = null)
        {
            Question = question;
            Answer = String.Empty;
        }
    }

    internal class BackwardChainedBartender
    {

        public event EventHandler<AskGuestEventArg>? AskGuestEvent;

        string AskGuest(string question, params string[] validOptions)
        {
            var eventArg = new AskGuestEventArg(question + (validOptions.Length > 0 ? " (" + string.Join(", ", validOptions) + ")" : ""));
            
            Dictionary<string, string> goodValues = new();
            foreach (string option in validOptions)
                goodValues.Add(option.ToUpper(), option);

            var badAnswer = true;
            do
            {
                AskGuestEvent?.Invoke(this, eventArg);

                if (goodValues.Count == 0)
                    badAnswer = false;
                else if(goodValues.ContainsKey(eventArg.Answer.ToUpper()))
                {
                    eventArg.Answer = goodValues[eventArg.Answer.ToUpper()];
                    badAnswer = false;
                }
            } while (badAnswer);
            
            return eventArg.Answer;
        }
        bool AskGuestYesNo(string question)
        {
            var eventArg = new AskGuestEventArg(question + " (Y, N)");
            Dictionary<string, bool> goodValues = new();
            goodValues.Add("Y", true);
            goodValues.Add("N", false);

            bool? answer = null;
            do
            {
                AskGuestEvent?.Invoke(this, eventArg);
                if (goodValues.ContainsKey(eventArg.Answer.ToUpper()))
                    answer = goodValues[eventArg.Answer.ToUpper()];

            } while (!answer.HasValue);

            return answer.Value;
        }
        DateOnly AskGuestForDate(string question)
        {
            var eventArg = new AskGuestEventArg(question + " [YYYY-MM-DD]");
            DateOnly? answer = null;
            do
            {
                AskGuestEvent?.Invoke(this, eventArg);
                if (DateOnly.TryParse(eventArg.Answer, out DateOnly date))
                    answer = date;
            } while (!answer.HasValue);

            return answer.Value;
        }




        public string[] TodaysSpecials()
        {
            if (_TodaysSpecials == null)
            {
                List<string> specials = new();
                specials.Add("Coke");
                specials.Add("Water");

                if (GuestAgeRange() != "Child")
                    specials.Add("Beer");

                if (GuestAgeRange() == "Old" && TodaysWeatherIs() == "Cold")
                    specials.Add("Irish Coffee");

                if (GuestAgeRange() == "Child" && TodaysWeatherIs() == "Hot")
                    specials.Add("Slush");

                _TodaysSpecials = specials.ToArray();
            }
            return _TodaysSpecials;
        }
        private string[]? _TodaysSpecials = null;


        public string DrinkOrder()
        {
            if (_DrinkOrder == null)
            {
                _DrinkOrder = AskGuest("What do you want to drink?", TodaysSpecials());
            }
            return _DrinkOrder;
        }
        private string? _DrinkOrder = null;


        public string ServerDrink()
        {
            if (_ServeDrink == null)
            {

                if ((DrinkOrder() == "Beer" || DrinkOrder() == "Irish Coffee") && GuestMayBuyAlcohol())
                    _ServeDrink = DrinkOrder();
                else if ((DrinkOrder() == "Beer" || DrinkOrder() == "Irish Coffee") && !GuestMayBuyAlcohol())
                    _ServeDrink = "Nothing";
                else
                    _ServeDrink = DrinkOrder();
            }
            return _ServeDrink;
        }
        private string? _ServeDrink = null;


        public bool GuestMayBuyAlcohol()
        {
            if (!_GuestMayBuyAlcohol.HasValue)
            {
                if (GuestAgeRange() == "Adult" || GuestAgeRange() == "Old")
                    _GuestMayBuyAlcohol = true;
                else if ((GuestAgeRange() == "Young Adult") && GuestIsVerifiedToBeOver18()) 
                    _GuestMayBuyAlcohol = true;
                else
                    _GuestMayBuyAlcohol = false;
            }
            return _GuestMayBuyAlcohol.Value;
        }
        private bool? _GuestMayBuyAlcohol = null;


        public bool GuestIsVerifiedToBeOver18()
        {
            if (!_GuestIsVerifiedToBeOver18.HasValue)
            {
                if (GuestHasID() && GuestBirthDate().AddYears(18) <= Today)
                    _GuestIsVerifiedToBeOver18 = true;
                else
                    _GuestIsVerifiedToBeOver18 = false;
            }
            return _GuestIsVerifiedToBeOver18.Value;
        }
        private bool? _GuestIsVerifiedToBeOver18 = null;

        public string TodaysWeatherIs()
        {
            if (_TodaysWeatherIs == null)
                _TodaysWeatherIs = AskGuest("How is todays weather?", "Hot", "Normal", "Cold");

            return _TodaysWeatherIs;
        }
        private string? _TodaysWeatherIs = null;

        public bool GuestHasID()
        {
            if (!_GuestHasID.HasValue)
                _GuestHasID = AskGuestYesNo("Does the guest have an ID to show?");

            return _GuestHasID.Value;
        }
        private bool? _GuestHasID = null;


        public DateOnly Today
        {
            get { return new(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day); }
        }


        public DateOnly GuestBirthDate()
        {
            if (!_GuestBirthDate.HasValue)
                _GuestBirthDate = AskGuestForDate("When was the guest born?");
            return _GuestBirthDate.Value;
        }
        private DateOnly? _GuestBirthDate = null;


        public string GuestAgeRange()
        {
            if (_GuestAgeRange == null)
                _GuestAgeRange = AskGuest("In what age range is the customer?", "Child","Young Adult", "Adult", "Old");

            return _GuestAgeRange;
        }
        private string? _GuestAgeRange = null;


    }
}
