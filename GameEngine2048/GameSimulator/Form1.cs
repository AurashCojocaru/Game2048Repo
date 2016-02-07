using GameEngine2048;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSimulator
{
    public partial class Form1 : Form
    {
        private GameEngine _engine;

        public Form1()
        {
            InitializeComponent();
            _engine = new GameEngine();
            int[,] startingMatrix = _engine.StartGame(4);
            DisplayMatrix(startingMatrix);
        }

        private void DisplayMatrix(int[,] matrix)
        {
            int size = (int)Math.Sqrt(matrix.Length);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(String.Format(" {0} ", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
