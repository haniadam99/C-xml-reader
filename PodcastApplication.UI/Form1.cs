using Podcast.Abstraction.Interfaces;
using Podcast.Abstraction.Models;
using Podcast.BusinessLayer;
using Podcast.InMemory.DataAccess;
using Podcast.Serializer.XML;
using PodcastBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PodcastApplication.UI
{
    public partial class Form1 : Form
    {
        PodcastManager service = null;
        PodcastScheduleService podcastSchedulerService;
        public Form1()
        {
            InitializeComponent();
            IPodcastDataAcess dataacess = new Podcast.InMemory.DataAccess.PodcastRepository();
            service = new PodcastManager(dataacess);
            podcastSchedulerService = new PodcastScheduleService(service);
            var serializePodcast = new PodcastxMLSerializer();
            service.DeserializeAsync();

            foreach (var savedPodcast in service.ListAsync().Result)
            {
                string[] podcastInfo = { savedPodcast.Name, savedPodcast.items.Count().ToString(), savedPodcast.Interval.ToString(), savedPodcast.Category, savedPodcast.UrlAdress };
                ListViewItem PodcastListDisplay = new ListViewItem(podcastInfo);
                listviewPodcast.Items.Add(PodcastListDisplay);
                if (savedPodcast.Category is object)
                    listboxCategory.Items.Add(savedPodcast.Category);
            }

            listviewPodcast.FullRowSelect = true;

            fillMyComboboxFrequency();
        }

        private void fillMyComboboxFrequency()
        {
            cbxFrequency.Items.Add("1");
            cbxFrequency.Items.Add("2");
            cbxFrequency.Items.Add("3");
        }
        private async void btnSearchPodcast_Click(object sender, EventArgs e)
        {
            try
            {//Klar Validering
                Validering.ValideraTextBoxUrl(txtSearchPodcast);

                //https://www.svt.se/rss.xml // https://rss.aftonbladet.se/rss2/small/pages/sections/sportbladet/
                var podcast = service.LoadAsync(txtSearchPodcast.Text);

                string[] podcastInfo = { podcast.Result.Name, podcast.Result.numberOfItems.ToString(), "" , "" , podcast.Result.UrlAdress};
                ListViewItem PodcastListDisplay = new ListViewItem(podcastInfo);

                listviewPodcast.Items.Add(PodcastListDisplay);

                await Task.CompletedTask;
            }
            catch(Exception)
            {
            }

        }

        private async void btnEpisodes_Click(object sender, EventArgs e)
        {//Klar Validering
            if (Validering.ValideraListview(listviewPodcast))
            {
                listboxEpisodes.Items.Clear();
                var SelectedPodcast = listviewPodcast.SelectedItems[0].SubItems[4].Text;
                var podcast = await service.GetAsync(SelectedPodcast);

                foreach (var podcastItems in podcast.items)
                {
                    listboxEpisodes.Items.Add(podcastItems.Name);
                }
            }
        }

        private void listboxEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listboxDescriptionOfEpisode.Items.Clear();
            var SelectedPodcast = listviewPodcast.SelectedItems[0].SubItems[4].Text;
            var podcast = service.GetAsync(SelectedPodcast);

            //flytta dessa till klass
            var itemTitle = listboxEpisodes.SelectedItem.ToString();
            var chosenEpisode = podcast.Result.items.Where(i => i.Name == itemTitle).FirstOrDefault();

            var c = chosenEpisode.Summary;
            listboxDescriptionOfEpisode.Items.Add(c);

        }

        private async void btnInsertCategory_Click(object sender, EventArgs e)
        {
            if (Validering.ValideraTextBox(txtInsertCategory))
            {
                if(listboxCategory.Items.Contains(txtInsertCategory.Text))
                {
                    MessageBox.Show("Denna kategori finns redan i listan");
                }
                else
                {
                    listboxCategory.Items.Add(txtInsertCategory.Text);
                    await Task.CompletedTask;

                }

            }
        }

     

        private void btnChangePodcastInfo_Click(object sender, EventArgs e)
        {//Klar validering
            
            if (Validering.ValideraTextBox(txtCategory) && Validering.ValideraTextBox(txtTitel) && Validering.ValideraComboBox(cbxFrequency))
            {
                listviewPodcast.SelectedItems[0].SubItems[3].Text = txtCategory.Text;
                listviewPodcast.SelectedItems[0].SubItems[2].Text = cbxFrequency.Text;
                listviewPodcast.SelectedItems[0].SubItems[0].Text = txtTitel.Text;
            }
        }

        private async void btnSavePodcast_Click(object sender, EventArgs e)
        {
            
            if (Validering.ValideraInfoFält(txtTitel, txtCategory, cbxFrequency))
            {
                var SelectedPodcast = listviewPodcast.SelectedItems[0].SubItems[4].Text;
                var podcast = service.GetAsync(SelectedPodcast);

                podcast.Result.Category = txtCategory.Text;
                podcast.Result.Interval = int.Parse(cbxFrequency.Text);
                podcast.Result.Name = txtTitel.Text;

                await service.LoadAllPodcastAsync(podcast.Result.UrlAdress, podcast.Result.Name, podcast.Result.Interval, podcast.Result.Category);
                podcastSchedulerService.AddPodcastTimer(podcast.Result);
                await service.SerializeAsync();
            }
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnDeletePodcast_Click(object sender, EventArgs e)
        {//Klar validering
            if(Validering.ValideraListview(listviewPodcast))
            {

                var SelectedPodcast = listviewPodcast.SelectedItems[0].SubItems[4].Text;
                var podcast = service.GetAsync(SelectedPodcast);

                var DeletedPodcast = service.DeleteAsync(podcast.Result);
                var UpdatedPodcastList = service.ListAsync();

                var serializePodcast = new PodcastxMLSerializer();
                await serializePodcast.SerializerAsync(UpdatedPodcastList.Result, "podcastlista.xml");

                foreach (ListViewItem eachItem in listviewPodcast.SelectedItems)
                {
                    listviewPodcast.Items.Remove(eachItem);
                }
            }
            
            }
        

        private void btnSortera_Click(object sender, EventArgs e)
        {//Klar validering
            if (Validering.ValideraListBox(listboxCategory))
            {
                listviewPodcast.Items.Clear();
                var SelectedCategory = listboxCategory.SelectedItem;

                var podcast = service.getAsyncByCategory(SelectedCategory.ToString());
                foreach (var savedPodcast in podcast.Result)
                {
                    string[] podcastInfo = { savedPodcast.Name, savedPodcast.items.Count().ToString(), savedPodcast.Interval.ToString(), savedPodcast.Category, savedPodcast.UrlAdress };
                    ListViewItem PodcastListDisplay = new ListViewItem(podcastInfo);
                    listviewPodcast.Items.Add(PodcastListDisplay);
                }
                listboxEpisodes.Items.Clear();
                listboxDescriptionOfEpisode.Items.Clear();
            }
        }

        private async void btnDeleteCategory_Click(object sender, EventArgs e)
       {//Klar validering
            if (Validering.ValideraListBox(listboxCategory))
            {
                DialogResult dialogResult = MessageBox.Show("Vill du ta bort denna kategori", "Ta bort kategori", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    txtCategory.Clear();
                    var SelectedCategory = listboxCategory.SelectedItem;
                    await service.DeleteByCategoryAsync(SelectedCategory.ToString());
                    listboxCategory.Items.RemoveAt(listboxCategory.SelectedIndex);
                    var podcasts = service.ListAsync();

                    var serializePodcast = new PodcastxMLSerializer();
                    await serializePodcast.SerializerAsync(podcasts.Result, "podcastlista.xml");
                    listviewPodcast.Items.Clear();

                    foreach (var savedPodcast in podcasts.Result)
                    {
                        string[] podcastInfo = { savedPodcast.Name, savedPodcast.items.Count().ToString(), savedPodcast.Interval.ToString(), savedPodcast.Category, savedPodcast.UrlAdress };
                        ListViewItem PodcastListDisplay = new ListViewItem(podcastInfo);
                        listviewPodcast.Items.Add(PodcastListDisplay);
                    }
                }

                /*DialogResult dialogResult = MessageBox.Show("Vill du ta bort denna kategori", "Ta bort kategori", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    listboxCategory.Items.RemoveAt(listboxCategory.SelectedIndex);
                }*/
                else if (dialogResult == DialogResult.No)
                {

                }
            
                


            }
        }



        private async void btnChangeCategory_Click(object sender, EventArgs e)
        {//klar validering
            if (Validering.ValideraListBox(listboxCategory) && Validering.ValideraTextBox(txtInsertCategory))
            {
                txtCategory.Clear();
                var SelectedCategory = listboxCategory.SelectedItem;
                listboxCategory.Items.Add(txtInsertCategory.Text);
                await service.ChangeCategoryAsync(txtInsertCategory.Text, SelectedCategory.ToString());
                listboxCategory.Items.Remove(SelectedCategory);
                var podcasts = service.ListAsync();


                await service.SerializeAsync();

                listviewPodcast.Items.Clear();

                foreach (var savedPodcast in podcasts.Result)
                {
                    string[] podcastInfo = { savedPodcast.Name, savedPodcast.items.Count().ToString(), savedPodcast.Interval.ToString(), savedPodcast.Category, savedPodcast.UrlAdress };
                    ListViewItem PodcastListDisplay = new ListViewItem(podcastInfo);
                    listviewPodcast.Items.Add(PodcastListDisplay);
                }
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
   
        }

        private void btnGetCategory_Click(object sender, EventArgs e)
        {
            if (Validering.ValideraListBox(listboxCategory))
            {
                txtCategory.Text = listboxCategory.SelectedItem.ToString();
            }
       
        }

        private void listboxDescriptionOfEpisode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

