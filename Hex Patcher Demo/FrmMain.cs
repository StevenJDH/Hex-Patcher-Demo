using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Patcher
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnPatch_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Executable files (*.exe)|*.exe";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                try
                {
                    Patch(filePath: path, offset: 0x222EE, currentByte: 0x15, newByte: 0x16);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType().Name}: {ex.Message}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Patches a byte at a specific offset using a new byte value.
        /// </summary>        
        /// <param name="filePath">Path to file</param>
        /// <param name="offset">Hex or decimal offset for the byte to patch</param>
        /// <param name="currentByte">hex or decimal value for the current byte at the provided offset</param>
        /// <param name="newByte">Hex of decimal value that will replace the current byte</param>
        /// <returns>True is successfully patched, false if there is an error</returns>
        public bool Patch(string filePath, int offset, byte currentByte, byte newByte)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                fs.Position = offset;

                // Checks to make sure we are dealing with the expected byte.
                if (fs.ReadByte() != currentByte)
                {
                    MessageBox.Show("File already patched, wrong file, wrong offset, or wrong expected byte.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // Rolls back one position since ReadByte()/WriteByte() advances by one automatically when used.
                fs.Position--;
                fs.WriteByte(newByte);
                // Move back again to offset position.
                fs.Position--; 

                //We do an extra step of checking to see if the byte was applied correctly as expected.
                if (fs.ReadByte() == newByte)
                {
                    MessageBox.Show("File successfully patched!",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error: Could not patch file.",
                        this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
