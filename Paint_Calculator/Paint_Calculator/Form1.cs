﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Paint_Calculator
{
    public partial class Form1 : Form
    {
        List<int> Input_Type = new List<int>(); // Holds the more complex information: numbers = 0, method = 1, Unit = 2; can then be used for visual translation

        List<Double> Input_Numbers = new List<Double>(); // Holds the Numeric values
        List<int> Input_Units = new List<int>(); // Holds more specific information for Units (0 - 3)
        List<Double> Input_Operators = new List<Double>(); // Holds more specific information for Methods(0 - 3)

        Double Section = 0; // Numbers and Operators fight for this variable

        // ram
        int Current_Section_Type = 0;// Numbers = 0, Operators = 1
        int Current_Section_Unit = 0; // (0 - 3)

        //Library
        string[] Unit_Values = { "mm", "cm", "m", "km" };
        string[] L_Operators = { "+", "-", "*", "/" };
        int[] Exchange_Rate = { 1000, 100, 1, 1000 };

        int Cycle = 0; // Cycles what Unit the user wants
        bool Decimal_Enable = false;

        #region Functions
        public void Number(Double x)
        {
            if (Current_Section_Type == 1) // Doesn't like Numbers
            {
                Input_Type.Add(1); // Adds Operator to type list be fore replacing it with Number type
                Input_Operators.Add(Section); // Adds the Operator to the Operator list
                
                Current_Section_Type = 0;
                Section = x;

                textBox1_Update(); // Run update for text box
            }
            else if (Decimal_Enable == true)
            {
                Section = Double.Parse(Section.ToString() + '.' + x.ToString());
                textBox2.Text = Section.ToString();
            }
            else
            {
                Section = Double.Parse(Section.ToString() + x.ToString()); // inputs number;
                textBox2.Text = Section.ToString();
            }
        }

        public void Operation(int x)
        {
            if (Current_Section_Type == 0) // Doesn't like Operators
            {
                Input_Type.Add(0); // add numbers to type list be fore replacing it with Operator type
                Input_Numbers.Add(Section); // add numbers to the visual list
                
                Input_Type.Add(2); // Adds the Unit type to the list
                Input_Units.Add(Current_Section_Unit); // adds the specific unit to the list

                Current_Section_Type = 1; // Finally does the Operator
                Section = (x);
                textBox2.Text = L_Operators[Convert.ToInt32(Section)];

                textBox1_Update();
            }
            else
            {
                Section = (x);
                textBox2.Text = L_Operators[Convert.ToInt32(Section)];
            }
        }

        public void Unit(int x)
        {
            Current_Section_Unit = x;
            button11.Text = Unit_Values[x];
        }

        public void textBox1_Update()
        {
            int Length = Input_Type.Count(); // Calculate the length of the list

            string Display = "";

            int Number_Count = 0;
            int Operator_Count = 0;
            int Unit_Count = 0;

            for (int i = 0; i < Length; i++)
            {
                switch (Input_Type[i])
                {
                    case 0: // Numerals
                        Display = Display + Input_Numbers[Number_Count];
                        Number_Count = Number_Count + 1;
                        break;

                    case 1: // Operators
                        Display = Display + L_Operators[Convert.ToInt32(Input_Operators[Operator_Count])];
                        Operator_Count = Operator_Count + 1;
                        break;

                    case 2: // Units
                        Display = Display + Unit_Values[Convert.ToInt32(Input_Units[Unit_Count])];
                        Unit_Count = Unit_Count + 1;
                        break;

                    default:
                        // Nothing
                        break;
                }
            }
            textBox1.Text = Display;
        }

        #endregion
        public Form1()
        {
            InitializeComponent();
        } //ignore for now
        
        // Holds the main numerical inputs (Includes Decimal)
        #region Number Input
        private void button1_Click(object sender, EventArgs e)
        {
            Number(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Number(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Number(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Number(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Number(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Number(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Number(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Number(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Number(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Number(0);
        }
        
        // Decimal
        private void button16_Click(object sender, EventArgs e)
        {
            if (Current_Section_Type == 0)
            {
                if (Decimal_Enable == true)
                    {
                        Decimal_Enable = false;
                    }
                else
                    {
                        Decimal_Enable = true;
                    }
            }
        }
        #endregion

        // Change Unit
        private void button11_Click(object sender, EventArgs e)
        {
            if (Cycle == 3)
            {
                Cycle = 0;
            }
            else
            {
                Cycle = Cycle + 1;
            }
            Unit(Cycle);
        }
        
        // Operators, Duh... (holds the inputs for operations like additon or division)
        #region Operators
        // Plus
        private void button12_Click(object sender, EventArgs e)
        {
            Operation(0);
        }

        // Minus
        private void button13_Click(object sender, EventArgs e)
        {
            Operation(1);
        }

        // Times
        private void button14_Click(object sender, EventArgs e)
        {
            Operation(2);
        }

        // Division
        private void button15_Click(object sender, EventArgs e)
        {
            Operation(3);
        }

        #endregion

        // Reset (resets averything before User Input (Ignoring Unit))
        private void button17_Click(object sender, EventArgs e)
        {
            Input_Type.Clear();

            Input_Numbers.Clear();
            Input_Units.Clear();
            Input_Operators.Clear();

            Section = 0;
            Current_Section_Type = 0;
        }
    }
}