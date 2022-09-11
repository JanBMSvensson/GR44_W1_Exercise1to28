using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR44_W1_Exercise1to28.CardClasses
{
    internal class CardCollection : System.Collections.ObjectModel.KeyedCollection<string, Card>

    {
        protected override string GetKeyForItem(Card item)
        {
            return item.ID;
        }

        public int HP
        {
            get
            {
                var sum = 0;
                foreach (Card card in this)
                    sum += card.HP;

                return sum;
            }
        }

        public string[] CardShortNames()
        {
            List<string> strings = new List<string>();
            foreach (Card card in this)
                strings.Add(card.ShortName);
            return strings.ToArray();
        }

    }
}
