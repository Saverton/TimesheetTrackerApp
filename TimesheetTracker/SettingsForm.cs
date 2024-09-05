using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetTracker
{
	public partial class SettingsForm : Form
	{
		private const string SUBKEY = "TimesheetTracker";
		private const string REGISTRY_PATH = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
		public SettingsForm()
		{
			InitializeComponent();
			UpdateStatusLabel();
		}

		private void OpenOnStartupCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (OpenOnStartupCheckBox.Checked == true)
			{
				var key = GetRegistryKey();
				key.SetValue(SUBKEY, Application.ExecutablePath.ToString());
			}
			else
			{
				var key = GetRegistryKey();
				if (key.GetValue(SUBKEY) is not null)
				{
					key.DeleteValue(SUBKEY);
				}
			}
		}

		private void UpdateStatusLabel()
		{
			var key = GetRegistryKey();

			var val = key.GetValue(SUBKEY)?.ToString();

			OpenOnStartupCheckBox.Checked = val is not null && val == Application.ExecutablePath.ToString();
		}

		private static RegistryKey GetRegistryKey()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH, true)!;

			return key;
		}
	}
}
