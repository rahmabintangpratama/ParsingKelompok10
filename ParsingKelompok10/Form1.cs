using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ParsingKelompok10
{
    public partial class ParsingKelompok10 : Form
    {
        private OpenFileDialog openFileDialog;

        public ParsingKelompok10()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files|*.json|All Files|*.*",
                Title = "Pilih File JSON"
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
                string jsonFilePath = openFileDialog.FileName;

                // Baca isi file JSON
                string jsonContent = File.ReadAllText(jsonFilePath);
                textBoxJsonContent.Text = jsonContent;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string jsonContent = textBoxJsonContent.Text;

            // Lakukan parsing JSON
            try
            {
                CheckJsonCompliance(jsonContent);
                MessageBox.Show("File JSON sesuai dengan ketentuan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = $"Error: {ex.Message}";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckJsonCompliance(string jsonContent)
        {
            // Lakukan validasi sesuai dengan ketentuan
            JObject jsonObj = JObject.Parse(jsonContent);

            // Reset output text box
            textBoxOutput.Text = "";

            // Dictionary untuk menyimpan informasi state model
            Dictionary<string, string> stateModels = new Dictionary<string, string>();
            HashSet<string> usedKeyLetters = new HashSet<string>();

            // List untuk menyimpan informasi keunikan nomor state
            HashSet<int> stateNumbers = new HashSet<int>();

            try
            {
                JToken modelToken = jsonObj["model"];
                if (modelToken != null && modelToken.Type == JTokenType.Array)
                {
                    foreach (var model in modelToken)
                    {
                        string objectType = model["type"]?.ToString();
                        string objectName = model["class_name"]?.ToString();

                        // Jika object adalah class
                        if (objectType == "class")
                        {
                            // Cek apakah ada assigner state model
                            string assignerStateModelName = $"{objectName}_ASSIGNER";

                            JToken assignerStateModelToken = jsonObj[assignerStateModelName];
                            if (assignerStateModelToken == null || assignerStateModelToken.Type != JTokenType.Object)
                            {
                                HandleError($"Sintax error number 16: Assigner state model tidak ditemukan untuk {objectName}.");
                                continue; // Lanjutkan ke iterasi berikutnya
                            }

                            string keyLetter = model["KL"]?.ToString();
                            string expectedKeyLetter = $"{keyLetter}_A";

                            // Cek apakah KeyLetter sesuai
                            JToken keyLetterToken = assignerStateModelToken[objectName]?["KeyLetter"];
                            if (keyLetterToken != null && keyLetterToken.ToString() != expectedKeyLetter)
                            {
                                HandleError($"Sintax error number 17: KeyLetter untuk {objectName} tidak sesuai dengan ketentuan.");
                            }

                            // Cek keunikan state model
                            CheckUniqueness(stateModels, assignerStateModelName, $"Sintax error number 17: State model {assignerStateModelName} tidak unik.");

                            // Cek keunikan state
                            CheckStateUniqueness(stateModels, assignerStateModelToken[objectName]?["states"], objectName);

                            // Cek keunikan nomor state
                            CheckStateNumberUniqueness(stateNumbers, assignerStateModelToken[objectName]?["states"], objectName);

                            // Cek keunikan KeyLetter
                            CheckKeyLetterUniqueness(usedKeyLetters, keyLetter, objectName);
                        }
                    }
                }

                // Cek keunikan Timer KeyLetter
                string timerKeyLetter = jsonObj["TIMER"]?["KeyLetter"]?.ToString();
                CheckKeyLetterUniqueness(usedKeyLetters, timerKeyLetter, "TIMER");

                // Cek event directed to one state model
                CheckEventDirectedToStateModel(jsonObj["model"], stateModels);
            }
            catch (Exception ex)
            {
                // Tampilkan pesan kesalahan setelah semua pengecekan selesai
                HandleError($"Error: {ex.Message}");
            }
        }

        // Fungsi untuk menangani kesalahan dan menambahkannya ke output text box
        private void HandleError(string errorMessage)
        {
            textBoxOutput.Text += $"{errorMessage}{Environment.NewLine}";
            // throw new Exception(errorMessage); // Hapus baris ini
        }

        // Fungsi untuk memeriksa keunikan state model
        private void CheckUniqueness(Dictionary<string, string> dictionary, string key, string errorMessage)
        {
            if (dictionary.ContainsKey(key))
            {
                HandleError(errorMessage);
            }
            else
            {
                dictionary.Add(key, key);
            }
        }

        // Fungsi untuk memeriksa keunikan state
        private void CheckStateUniqueness(Dictionary<string, string> stateModels, JToken statesToken, string objectName)
        {
            if (statesToken is JArray states)
            {
                foreach (var state in states)
                {
                    string stateName = state["state_name"]?.ToString();
                    string stateModelName = $"{objectName}.{stateName}";

                    // Cek keunikan state model
                    CheckUniqueness(stateModels, stateModelName, $"Sintax error number 18: State {stateModelName} tidak unik.");
                }
            }
        }

        // Fungsi untuk memeriksa keunikan nomor state
        private void CheckStateNumberUniqueness(HashSet<int> stateNumbers, JToken statesToken, string objectName)
        {
            if (statesToken is JArray stateArray)
            {
                foreach (var state in stateArray)
                {
                    int stateNumber = state["state_number"]?.ToObject<int>() ?? 0;

                    if (!stateNumbers.Add(stateNumber))
                    {
                        HandleError($"Sintax error number 19: Nomor state {stateNumber} tidak unik.");
                    }
                }
            }
        }

        // Fungsi untuk memeriksa keunikan KeyLetter
        private void CheckKeyLetterUniqueness(HashSet<string> usedKeyLetters, string keyLetter, string objectName)
        {
            if (!usedKeyLetters.Add(keyLetter))
            {
                HandleError($"Sintax error number 20: KeyLetter untuk {objectName} tidak unik.");
            }
        }

        // Fungsi untuk memeriksa event directed to one state model
        private void CheckEventDirectedToStateModel(JToken modelsToken, Dictionary<string, string> stateModels)
        {
            if (modelsToken is JArray models)
            {
                foreach (var model in models)
                {
                    string modelName = model["class_name"]?.ToString();
                    CheckEventDirectedToStateModelHelper(model["states"], stateModels, modelName);
                }
            }
        }

        private void CheckEventDirectedToStateModelHelper(JToken statesToken, Dictionary<string, string> stateModels, string modelName)
        {
            if (statesToken is JArray states)
            {
                foreach (var state in states)
                {
                    string stateName = state["state_name"]?.ToString();
                    string stateModelName = $"{modelName}.{stateName}";

                    if (stateModels.ContainsKey(stateModelName))
                    {
                        HandleError($"Sintax error number 24: State {stateModelName} tidak sesuai dengan ketentuan.");
                    }
                }
            }
        }
    }
}