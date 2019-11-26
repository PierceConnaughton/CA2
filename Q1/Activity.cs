using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    //enum for each activity type
    enum ActivityType
    {
        Air,
        Water,
        Land
    }
    class Activity : IComparable
    {
        #region Properties

        //properties for description name activity type cost and activity type
        private string _description;
       

        public string Name { get; set; }

       
        public DateTime ActivityDateTime { get; set; }
     


        public decimal Cost { get; set; }
       

        
        public string Description
        {
            get
            {
                
                return _description;
            }
            set
            {
             
                _description = value;
            }
        }

        public ActivityType SuitableFor { get; set; }

        #endregion Properties

        #region Constructors
        //constructor for activity with all arguments met
        public Activity(string name,DateTime activityDateTime,decimal cost,string description, ActivityType suitableFor)
        {
            Name = name;
            ActivityDateTime = activityDateTime;
            Cost = cost;
            Description = description;
            SuitableFor = suitableFor;
        }

        public Activity()
        {

        }
        #endregion Constructors

        #region Methods
        //Compare the current objects date of time with the last one too see which one is earlier
        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;

            return this.ActivityDateTime.CompareTo(that.ActivityDateTime);
        }

        //too string method that displays name cost and activity date
        public override string ToString()
        {
            string activityDate = ActivityDateTime.ToShortDateString();
            return $"{Name} - {Cost} - {activityDate}";
        }

        //srting method for description
        public string DescriptionString()
        {
            return Description;
        }
        #endregion Methods
    }
}
