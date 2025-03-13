using System;
using System.Collections.Generic;

namespace Temp_System_Delegate
{
    public class Broker
    {
        //create a dic for hold subject & subscribers.
        private Dictionary<string, List<Action<TempArgs>>> _SubscriberList = new Dictionary<string, List<Action<TempArgs>>>();

        public void Subscribe(string subject, Action<TempArgs> action)
        {
            if (!_SubscriberList.ContainsKey(subject))
            {
                _SubscriberList[subject] = new List<Action<TempArgs>>();
            }
            //adding the(handler)to the subscriptionist.
            _SubscriberList[subject].Add(action);

        }
        public void Publish(string subject, TempArgs message)
        {
            if (_SubscriberList.ContainsKey(subject))
            {
                List<Action<TempArgs>> subscribersToSubject = _SubscriberList[subject];

                foreach (var item in subscribersToSubject)
                {
                    item.Invoke(message);
                }
            }

        }
    }
}
