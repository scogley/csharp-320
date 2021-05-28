using ContactApp.Models;
using System.Linq;
using System.Windows;
using System.ComponentModel; // added for column sorting
using System.Windows.Controls; // added for column sorting
using System.Windows.Documents; // added for column sorting
using System.Windows.Data;
using System.Windows.Media; // added for Geometry

namespace ContactApp
{
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null; // added for column sorting
        private SortAdorner listViewSortAdorner = null; // added for column sorting
        private ContactModel selectedContact;

        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();


        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();
            uxContextFileDelete_Set_Enabled_State();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }

        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                        AdornedElement.RenderSize.Width - 15,
                        (AdornedElement.RenderSize.Height - 5) / 2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        private void lvNameColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you clicked the name column!");
        }
        private void lvEmailColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you clicked the Email column!");
        }
        private void lvPhoneTypeColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you clicked the PhoneType column!");
        }

        private void lvPhoneNumberColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you clicked the PhoneNumber column!");
        }

        private void lvAgeColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("you clicked the Age column!");
        }

        // sort the columns
        private void SortGridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxContactList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxContactList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
            //if (selectedContact == null) uxContextFileDelete.IsEnabled = false;
            uxContextFileDelete_Set_Enabled_State();
        }

        

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
        }

        private void uxContextFileDelete_Set_Enabled_State()
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
            if (selectedContact == null) uxContextFileDelete.IsEnabled = false;
            else uxContextFileDelete.IsEnabled = true;
        }
    }
}