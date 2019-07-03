/*
 * Created by SharpDevelop.
 * User: hamza
 * Date: 03/29/2018
 * Time: 13:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Menu
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class UserControl1 : UserControl
	{
		public UserControl1()
		{
			InitializeComponent();
		}
		public void intitialize(FontAwesome.WPF.FontAwesomeIcon f, String s,String s2){
			icon.Icon = f;
			title.Content = s;
			number.Content =s2;
		}
	}
}