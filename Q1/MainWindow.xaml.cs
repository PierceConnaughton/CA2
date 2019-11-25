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
        decimal total = 0;
        List<Activity> activityList = new List<Activity>();
        List<Activity> selectedList = new List<Activity>();

        Activity act1 = new Activity("Kayaking", new DateTime(2019, 10, 13), 20, "We went Kayaking");
        Activity act2 = new Activity("Parachuting", new DateTime(2019, 10, 12), 30, "We went Parachuting");
        Activity act3 = new Activity("Mountain Biking", new DateTime(2019, 10, 13), 15, "We went Mountain Biking");
        Activity act4 = new Activity("Hang Gliding", new DateTime(2019, 10, 05), 25, "We went Hang Gliding");
        Activity act5 = new Activity("Abseiling", new DateTime(2019, 10, 06), 30, "We went Abseiling");
        Activity act6 = new Activity("Sailing", new DateTime(2019, 10, 09), 40, "We went Sailing");
        Activity act7 = new Activity("Helicopter Tour", new DateTime(2019, 10, 11), 70, "We went on a Helicopter Tour");



 
        
        public MainWindow()
        {
            InitializeComponent();


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            Activity selectedActivity = lstAllActivties.SelectedItem as Activity;

            if (selectedActivity == null)
            {

            }
            else
            {
                
                txtBlDescription.Text = selectedActivity.Description;
            }
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = lstAllActivties.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                activityList.Remove(selectedActivity);
                selectedList.Add(selectedActivity);

                
                total = total + selectedActivity.Cost;

                

                
                
                

                RefreshScreen();
            }
        }

        private void RefreshScreen()
        {
            lstAllActivties.ItemsSource = null;
            activityList.Sort();
            
            lstAllActivties.ItemsSource = activityList;

            lstBxSelected.ItemsSource = null;
            selectedList.Sort();
            lstBxSelected.ItemsSource = selectedList;

            TxtTotal.Text = null;
            TxtTotal.Text = string.Format("{0:c}", total);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Activity selectedActivity = lstBxSelected.SelectedItem as Activity;

            if (selectedActivity != null)
            {
                activityList.Add(selectedActivity);
                selectedList.Remove(selectedActivity);

                total = total - selectedActivity.Cost;

               



                RefreshScreen();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            activityList.Add(act1);
            activityList.Add(act2);
            activityList.Add(act3);
            activityList.Add(act4);
            activityList.Add(act5);
            activityList.Add(act6);
            activityList.Add(act7);

            activityList.Sort();

            lstAllActivties.ItemsSource = activityList;
        }
    }
}
