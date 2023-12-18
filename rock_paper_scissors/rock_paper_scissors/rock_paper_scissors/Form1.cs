﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rock_paper_scissors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // ход игрока
        int rck = 0;
        int scis = 0;
        int ppr = 0;
        // ход бота
        int rckbot = 0;
        int pprbot = 0;
        int scisbot = 0;
        int viborbot = 0; // рнадомный выбор бота
        int botwin = 0; // счетчик побед бота
        int playerwin = 0; // счетчик побед игрока
        Random rnd = new Random(); // функция для рандомного определения хода бота
        private void button1_Click(object sender, EventArgs e) //выбор при нажатии соответствующей кнопки
        {
            rck = 1;
            bot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scis = 1;
            bot();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ppr = 1;
            bot();
        }
        public void zero() // обнуление после заверешения одного хода
        {
            rck = 0;
            ppr = 0;
            scis = 0;
            rckbot = 0;
            pprbot = 0;
            scisbot = 0;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
        // алитернатива на c++
        //void zero()
        //{
        //    rck = 0;
        //    ppr = 0;
        //    scis = 0;
        //    rckbot = 0;
        //    pprbot = 0;
        //    scisbot = 0;
        //    // Удаление изображения из pictureBox1 и pictureBox2
        //    pictureBox1->Image = nullptr;
        //    pictureBox2->Image = nullptr;
        //}
        public void bot() // функция хода бота
        {
            if (scis == 1) { pictureBox1.Image = Properties.Resources.scissors; }
            if (ppr == 1) { pictureBox1.Image = Properties.Resources.paper; }
            if (rck == 1) { pictureBox1.Image = Properties.Resources.rock; }
            viborbot = rnd.Next(1, 16); // рандом бота (16, так как для справедливого разнообразия и интереса игры на каждую позицию (камень, ножницы, бумага) будет отдано 5 чисел)
            if ((viborbot >= 1) && (viborbot <= 5)) // выбор бота = камень
            {
                rckbot = 1; // бот выбрал камень
                if (scis == 1) // если у игрока ножницы
                {
                    pictureBox2.Image = Properties.Resources.rock;
                    MessageBox.Show("Победа бота");
                    zero();
                    botwin++;
                    label2.Text = "Бот: " + botwin;
                }
                if (rck == 1) // если и игрок и бот выбрали камень
                {
                    pictureBox2.Image = Properties.Resources.rock; // изображение бота - камень
                    MessageBox.Show("Ничья"); // вывод
                    zero();
                }
                if (ppr == 1) // у игрока бумага
                {
                    pictureBox2.Image = Properties.Resources.rock; // вывод камня бота
                    MessageBox.Show("Победил игрок"); // вывод
                    playerwin++; // + к счету игрока
                    label1.Text = "Игрок: " + playerwin;
                    zero();
                }
            }
            else
            {
                if ((viborbot >= 6) && (viborbot <= 10)) // выбор бота = ножницы
                {
                    scisbot = 1; // ножницы у бота
                    if (scis == 1)
                    {
                        pictureBox2.Image = Properties.Resources.scissors; // изображение бота - бумага
                        MessageBox.Show("Ничья"); // вывод
                        zero();
                    }
                    if (rck == 1) // у игрока камень 
                    {
                        pictureBox2.Image = Properties.Resources.scissors; // вывод бумаги бота
                        MessageBox.Show("Победил игрок"); // вывод
                        playerwin++; // + к счету игрока
                        label1.Text = "Игрок: " + playerwin;
                        // chance -= 10; // шанс победы бота увеличивается при победе игрока
                        zero();
                    }
                    if (ppr == 1) // у игрока бумага 
                    {
                        pictureBox2.Image = Properties.Resources.scissors; // вывод бумаги бота
                        MessageBox.Show("Победил бот"); // вывод
                        botwin++; // + к счету бота
                        label2.Text = "Бот: " + botwin;
                        // chance -= 10; // шанс победы бота увеличивается при победе игрока
                        zero();
                    }
                }
                else
                {
                    if ((viborbot >= 11) && (viborbot <= 15)) // выбор бота = бумага
                    {
                        pprbot = 1; // у бота ножницы
                        if (ppr == 1) // если и игрок и бот выбрали бумагу
                        {
                            pictureBox2.Image = Properties.Resources.paper; // изображение бота - бумага
                            MessageBox.Show("Ничья"); // вывод
                            zero();
                        }
                        if (scis == 1) // у игрока ножницы
                        {
                            pictureBox2.Image = Properties.Resources.paper; // вывод бумаги бота
                            MessageBox.Show("Победил игрок"); // вывод
                            playerwin++; // + к счету игрока
                            label1.Text = "Игрок: " + playerwin;
                            zero();
                        }
                        if (rck == 1) // у игрока камень
                        {
                            pictureBox2.Image = Properties.Resources.paper; // вывод бумаги бота
                            MessageBox.Show("Победил бот"); // вывод
                            botwin++; // + к счету бота
                            label2.Text = "Бот: " + botwin;
                            zero();
                        }
                    }
                }
            }
        }
    }
}

        //void bot()
        //{
        //    if (scis == 1) { pictureBox1->Image = Properties::Resources::scissors; }
        //    if (ppr == 1) { pictureBox1->Image = Properties::Resources::paper; }
        //    if (rck == 1) { pictureBox1->Image = Properties::Resources::rock; }
        //    viborbot = rnd.Next(1, 16); // рандом бота
        //    if ((viborbot >= 1) && (viborbot <= 5)) // выбор бота = камень
        //    {
        //        rckbot = 1; // бот выбрал камень
        //        if (scis == 1) // если у игрока ножницы
        //        {
        //            pictureBox2->Image = Properties::Resources::rock;
        //            MessageBox::Show("Победа бота");
        //            zero();
        //            botwin++;
        //            label2.Text = "Бот: " + botwin;
        //        }
        //        if (rck == 1) // если и игрок и бот выбрали камень
        //        {
        //            pictureBox2->Image = Properties::Resources::rock; // изображение бота - камень
        //            MessageBox::Show("Ничья"); // вывод
        //            zero();
        //        }
        //        if (ppr == 1) // у игрока бумага
        //        {
        //            pictureBox2->Image = Properties::Resources::rock; // вывод камня бота
        //            MessageBox::Show("Победил игрок"); // вывод
        //            playerwin++; // + к счету игрока
        //            label1.Text = "Игрок: " + playerwin;
        //            zero();
        //        }
        //    }
        //    else
        //    {
        //        if ((viborbot >= 6) && (viborbot <= 10)) // выбор бота = ножницы
        //        {
        //            scisbot = 1; // ножницы у бота
        //            if (scis == 1)
        //            {
        //                pictureBox2->Image = Properties::Resources::scissors; // изображение бота - бумага
        //                MessageBox::Show("Ничья"); // вывод
        //                zero();
        //            }
        //            if (rck == 1) // у игрока камень 
        //            {
        //                pictureBox2->Image = Properties::Resources::scissors; // вывод бумаги бота
        //                MessageBox::Show("Победил игрок"); // вывод
        //                playerwin++; // + к счету игрока
        //                label1.Text = "Игрок: " + playerwin;
        //                zero();
        //            }
        //            if (ppr == 1) // у игрока бумага 
        //            {
        //                pictureBox2->Image = Properties::Resources::scissors; // вывод бумаги бота
        //                MessageBox::Show("Победил бот"); // вывод
        //                botwin++; // + к счету бота
        //                label2.Text = "Бот: " + botwin;
        //                zero();
        //            }
        //        }
        //        else
        //        {
        //            if ((viborbot >= 11) && (viborbot <= 15)) // выбор бота = бумага
        //            {
        //                pprbot = 1; // у бота ножницы
        //                if (ppr == 1) // если и игрок и бот выбрали бумагу
        //                {
        //                    pictureBox2->Image = Properties::Resources::paper; // изображение бота - бумага
        //                    MessageBox::Show("Ничья"); // вывод
        //                    zero();
        //                }
        //                if (scis == 1) // у игрока ножницы
        //                {
        //                    pictureBox2->Image = Properties::Resources::paper; // вывод бумаги бота
        //                    MessageBox::Show("Победил игрок"); // вывод
        //                    playerwin++; // + к счету игрока
        //                    label1.Text = "Игрок: " + playerwin;
        //                    zero();
        //                }
        //                if (rck == 1) // у игрока камень
        //                {
        //                      if (rck == 1) // у игрока камень
        //                      {
        //                          pictureBox2->Image = Properties::Resources::paper; // вывод бумаги бота
        //                          MessageBox::Show("Победил бот"); // вывод
        //                          botwin++; // + к счету бота
        //                          label2->Text = "Бот: " + botwin;
        //                          zero();
        //                       }
        //                   }
                    //    }
                    //}

