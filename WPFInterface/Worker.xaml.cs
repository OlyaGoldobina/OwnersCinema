﻿using LibraryOfClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;


namespace WPFInterface
{
    /// <summary>
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Window
    {
        WorkerRepository _repo = new WorkerRepository();
        public Worker()
        {
            InitializeComponent();
        }

        private void UpdateSessions()
        {
//            List<Worker> thisses = _repo.SelectItem();
//            FilmItems.ItemsSource = null;
//            FilmItems.ItemsSource = thisses;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Choise choisewindow = new Choise();
            choisewindow.Show();
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            WorkersInformation workerwindow = new WorkersInformation();
            workerwindow.Show();
            this.Close();
        }
    }
}
