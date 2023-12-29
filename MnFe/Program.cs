﻿using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Threading;
using GameMaker;
using MyWork;

// 事件
namespace EventExample
{
    class Program
    {
        public bool[,,] ReadonlyCells { get; } = new bool[2, 3, 3];

        public String StrIt { get; set; }
        static void Main(string[] args)
        {
            string a = "杀";
            string b = "借刀杀人m";
            Print(a.Length);
            Print(b.Length);
        }

        static void TestForExcel2HTML(){
            string thispath = System.Environment.CurrentDirectory;
            Console.WriteLine(thispath + "/MyWork/data.xlsx");
            var db = Excel2HTML.Excel2Table(thispath + "/MyWork/data.xlsx", CompareFlag.Compare);
        }

        static void TestForEvent(){
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayTheBill();
        }

        static void Print(object print){
            string output = "";
            if(print != null){
                output = print.ToString();
            }
            Console.WriteLine(output);
        }
    }

    public class OrderEventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        /*
        private OrderEventHandler orderEventHandler;

        public event OrderEventHandler Order
        {
            add { this.orderEventHandler += value; }
            
            remove { this.orderEventHandler -= value; }
        }
        */
        public static int NextId = 1;

        public int Id {get;}

        public Customer(){
            Id = NextId;
            NextId++;
        }
        public event OrderEventHandler Order;
        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk in the rest");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down") ;
        }

        public void Tnink()
        {
            for (int i = 0;i <5; i++)
            {
                Console.WriteLine("Let me think..") ;
                Thread.Sleep(500) ;
            }

            // 完整声明
            /*if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.orderEventHandler.Invoke(this, e);
            }*/
            // 语法糖声明
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";
                this.Order.Invoke(this, e);
            }

        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Tnink();
        }
    }

    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish {0}", e.DishName);
            double price = 10;
            switch(e.Size)
            {
                case "small":
                    customer.Bill = price * 0.5;
                    break;
                case "large":
                    customer.Bill = price * 1.5;
                    break;
                default:
                    customer.Bill = price;
                    break;
            }
        }
    }

}