﻿using AppSalesMan2.Models;
using AppSalesMan2.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppSalesMan2.Windows.ChangeWindows
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeLogisticWindow.xaml
    /// </summary>
    public partial class ChangeLogisticWindow : Window
    {
        private readonly int _Id;
        readonly CustomerListWindow CustomerListWindow;
        readonly CustomerModel SelectedCustomer = new CustomerModel();
        readonly ChangeRequestModelRepository ChangeRepository = new ChangeRequestModelRepository();
        readonly CustomerModelRepository Repository = new CustomerModelRepository();
        public ChangeLogisticWindow(CustomerModel SelectedRow, CustomerListWindow customerListWindow, int SalesManId)
        {
            _Id = SalesManId;
            this.CustomerListWindow = customerListWindow;
            this.SelectedCustomer = SelectedRow;
            InitializeComponent();
            txtExistingLogistic.Text = SelectedRow.Logistic;
        }


        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            ChangeRequestModel NewRequest = new ChangeRequestModel
            {
                CompanyID = SelectedCustomer.CompanyID,
                Parameter = SelectedCustomer.Logistic,
                NewParameter = txtNewLogistic.Text,
                Action = "ChangeLogistic",
                SalesManId = _Id

            };
            ChangeRepository.AddRequest(NewRequest);
            Repository.ChangeRequest(SelectedCustomer);
            CustomerListWindow.CustomerList.CustomerList = Repository.GetSalesManCustomerList(_Id);
            this.Close();

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
