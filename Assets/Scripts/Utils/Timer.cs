using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Utils
{
    public class Timer
    {
        public float Progress { get; set; }
        public float Goal { get; set; }
        public int Percentage { get {

                return (int)((Progress / Goal)*100);
            } }
        public Timer(int second)
        {
            Goal = second;
        }
        public void Update()
        {
            Progress += Time.deltaTime;
            if (Progress>=Goal)
            {
                if (OnTimerComplete!=null)
                {
                    OnTimerComplete(this, null);
                }
              
            }
        }
        public event EventHandler OnTimerComplete;
    }
}
