using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //total amount it cost's at the start
        decimal total = 0;
        //when we start description should automatically say nothing is selected
        string description = "Nothing Selected";

        //lists for my entire activities the activities i selected too add and the filtred list for each activity type
        List<Activity> activityList = new List<Activity>();
        List<Activity> selectedList = new List<Activity>();
        List<Activity> filteredList = new List<Activity>();


        //all the activities I created
        Activity act1 = new Activity("Kayaking", new DateTime(2019, 10, 13), 20, "We went Kayaking", ActivityType.Water);
        Activity act2 = new Activity("Parachuting", new DateTime(2019, 10, 12), 30, "We went Parachuting", ActivityType.Air);
        Activity act3 = new Activity("Mountain Biking", new DateTime(2019, 10, 13), 15, "We went Mountain Biking", ActivityType.Land);
        Activity act4 = new Activity("Hang Gliding", new DateTime(2019, 10, 13), 25, "We went Hang Gliding", ActivityType.Air);
        Activity act5 = new Activity("Abseiling", new DateTime(2019, 10, 06), 30, "We went Abseiling", ActivityType.Land);
        Activity act6 = new Activity("Sailing", new DateTime(2019, 10, 09), 40, "We went Sailing", ActivityType.Water);
        Activity act7 = new Activity("Helicopter Tour", new DateTime(2019, 10, 11), 70, "We went on a Helicopter Tour", ActivityType.Air);





        public MainWindow()
        {
            InitializeComponent();

        }

        //when an item in the activites list is selected
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lstAllActivties.SelectedItem as Activity;

            //if nothing is selected
            if (selectedActivity == null)
            {

            }

            else
            {
                //display the description of the item I selected
                description = string.Format(selectedActivity.DescriptionString() + ", Cost : " + "{0:c}", selectedActivity.Cost);
                txtBlDescription.Text = null;
                txtBlDescription.Text = description;

            }

        }

        //if the add button is clicked
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lstAllActivties.SelectedItem as Activity;

            //if selected activity is picked
            if (selectedActivity != null)
            {
                //foreach activity in activity selected list
                foreach (Activity activity in selectedList)
                {
                    //check if the selected date has same date as any date in the list of already selected activitys 
                    if (selectedActivity.ActivityDateTime == activity.ActivityDateTime)
                    {
                        //if the date is the same display an error message and return
                        MessageBox.Show(selectedActivity.Name + " has same date as " +  activity.Name +  " cannot add if date is same");
                        return;
                    }

                }
                //remove it from the entire all activity's list and add it too the selected activity's list
                activityList.Remove(selectedActivity);
                selectedList.Add(selectedActivity);

                //add the total of the selected activity
                total = total + selectedActivity.Cost;


                if (rbAir1.IsChecked == true)
                {
                    foreach (Activity activity in activityList)
                    {
                        //if one of the activities is of type air is found add it too filtered list and display it
                        if (activity.SuitableFor == ActivityType.Air)
                        {
                            filteredList.Remove(selectedActivity);
                            filteredList.Sort();


                            if (filteredList.Count == 0)
                            {
                                MessageBox.Show("No Air Activity's Found");
                                RefreshScreen();
                            }
                            else
                            {
                                lstAllActivties.ItemsSource = null;
                                lstAllActivties.ItemsSource = filteredList;

                                lstBxSelected.ItemsSource = null;
                                selectedList.Sort();
                                lstBxSelected.ItemsSource = selectedList;

                                //display the total cost of all the selected activity's in the selected activity's list
                                TxtTotal.Text = null;
                                TxtTotal.Text = string.Format("{0:c}", total);

                                return;
                            }
                        }
                    }
                }
                else if (rbLand.IsChecked == true)
                {
                    foreach (Activity activity in activityList)
                    {
                        //if one of the activities is of type air is found add it too filtered list and display it
                        if (activity.SuitableFor == ActivityType.Air)
                        {
                            filteredList.Remove(selectedActivity);
                            filteredList.Sort();


                            if (filteredList.Count == 0)
                            {
                                MessageBox.Show("No Land Activity's Found");
                                RefreshScreen();
                            }
                            else
                            {
                                lstAllActivties.ItemsSource = null;
                                lstAllActivties.ItemsSource = filteredList;

                                lstBxSelected.ItemsSource = null;
                                selectedList.Sort();
                                lstBxSelected.ItemsSource = selectedList;

                                //display the total cost of all the selected activity's in the selected activity's list
                                TxtTotal.Text = null;
                                TxtTotal.Text = string.Format("{0:c}", total);

                                return;
                            }
                        }
                    }
                }
                else if (rbWater.IsChecked == true)
                {
                    if (filteredList.Count == 0)
                    {
                        MessageBox.Show("No Water Activity's Found");
                        RefreshScreen();
                    }
                    else
                    {
                        foreach (Activity activity in activityList)
                        {
                            //if one of the activities is of type air is found add it too filtered list and display it
                            if (activity.SuitableFor == ActivityType.Water)
                            {
                                filteredList.Remove(selectedActivity);
                                filteredList.Sort();


                                if (filteredList.Count == 0)
                                {
                                    MessageBox.Show("No Water Activity's Found");
                                    RefreshScreen();
                                }
                                else
                                {
                                    lstAllActivties.ItemsSource = null;
                                    lstAllActivties.ItemsSource = filteredList;

                                    lstBxSelected.ItemsSource = null;
                                    selectedList.Sort();
                                    lstBxSelected.ItemsSource = selectedList;

                                    //display the total cost of all the selected activity's in the selected activity's list
                                    TxtTotal.Text = null;
                                    TxtTotal.Text = string.Format("{0:c}", total);

                                    return;
                                }
                            }
                        }
                    
                    }
                }
                //refresh the screen method
                RefreshScreen();
            }
            else
            {
                //if nothing is selected and add is clicked on show this message
                MessageBox.Show("Nothing Selected");
            }



        }

        //refresh screen method
        private void RefreshScreen()
        {
            //gets the current list of all activitys and selected activity's and displays this current list too the screen
            lstAllActivties.ItemsSource = null;

            //sorts the list by date
            activityList.Sort();

            lstAllActivties.ItemsSource = activityList;

            lstBxSelected.ItemsSource = null;
            selectedList.Sort();
            lstBxSelected.ItemsSource = selectedList;

            //display the total cost of all the selected activity's in the selected activity's list
            TxtTotal.Text = null;
            TxtTotal.Text = string.Format("{0:c}", total);

            
        }

        //on remove button clicked
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lstBxSelected.SelectedItem as Activity;

            //if selected activity is chosen
            if (selectedActivity != null)
            {

                //remove it from the selected activitys list and add it back too the activities list
                activityList.Add(selectedActivity);
                selectedList.Remove(selectedActivity);

                //remove the cost of the selected activity from the total cost
                total = total - selectedActivity.Cost;

                RefreshScreen();

            }
            else
            {
                MessageBox.Show("Nothing Selected");
            }
        }
        //on load
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //on load add all activities too the activity list and sort it via date
            activityList.Add(act1);
            activityList.Add(act2);
            activityList.Add(act3);
            activityList.Add(act4);
            activityList.Add(act5);
            activityList.Add(act6);
            activityList.Add(act7);

            activityList.Sort();

            //display the list of activities and the description
            lstAllActivties.ItemsSource = activityList;

            txtBlDescription.Text = description;
        }
        //when an item is selected in selected list
        private void lstBxSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            
            Activity selectedActivity2 = lstBxSelected.SelectedItem as Activity;

            if (selectedActivity2 == null)
            {

            }
            
            else
            {
                //display the description when selected activity is picked from selected activties list
                
                description = string.Format(selectedActivity2.DescriptionString() + ", Cost : " + "{0:c}",selectedActivity2.Cost);


                txtBlDescription.Text = null;
                txtBlDescription.Text = description;
            }
            
        }

        //when any radio button is clicked
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            //clear the current filtered list
            filteredList.Clear();

            //if radio button all is checked show the entire list
            if (rbAll.IsChecked == true)
            {
                RefreshScreen();
                
            }
            //if radio button air is checked 
            else if (rbAir1.IsChecked == true)
            {

                //go through all activities
                foreach (Activity activity in activityList)
                {
                    //if one of the activities is of type air is found add it too filtered list and display it
                    if (activity.SuitableFor == ActivityType.Air)
                    {
                        filteredList.Add(activity);
                        

                        if (filteredList.Count == 0)
                        {
                            MessageBox.Show("No Air Activity's Found");
                            RefreshScreen();
                        }
                        else
                        {
                            lstAllActivties.ItemsSource = null;
                            lstAllActivties.ItemsSource = filteredList;
                        }
                    }
                }
            }

            //if radio button land is checked 
            else if (rbLand.IsChecked == true)
            {
                //go through all activities
                foreach (Activity activity in activityList)
                {
                    //if one of the activities is of type land is found add it too filtered list and display it
                    if (activity.SuitableFor == ActivityType.Land)
                    {
                        filteredList.Add(activity);


                        if (filteredList.Count == 0)
                        {
                            MessageBox.Show("No Land Activity's Found");
                            RefreshScreen();
                        }
                        else
                        {
                            lstAllActivties.ItemsSource = null;
                            lstAllActivties.ItemsSource = filteredList;
                        }
                    }
                }
            }

            //if radio button water is checked 
            else if (rbWater.IsChecked == true)
            {

                //go through all activities
                foreach (Activity activity in activityList)
                {   
                    //if one of the activities is of type water is found add it too filtered list and display it
                    if (activity.SuitableFor == ActivityType.Water)
                    {
                        filteredList.Add(activity);


                        if (filteredList.Count == 0)
                        {
                            MessageBox.Show("No Water Activity's Found");
                            RefreshScreen();
                        }
                        else
                        {
                            lstAllActivties.ItemsSource = null;
                            lstAllActivties.ItemsSource = filteredList;
                        }
                    }
                }

                
            }
            }
        }
    }

    

