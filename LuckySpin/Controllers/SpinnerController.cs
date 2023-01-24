﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LuckySpin.Models;
using LuckySpin.Services;
using System.Globalization;
using static System.Formats.Asn1.AsnWriter;
using LuckySpin.ViewModels;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        /**
         * DIJ in 4 STEPS -
         * 0) Register the Repository class as a service in Program.cs 
         * 1) add an instance variable here of type Repository
         * 2) In the Constructor, call for a DIJ Repository object to be passed to the constructor
         **/
        private Repository repository;
        private decimal currentBalance;

        public SpinnerController(Repository repository)
        {
            // 3) TODO: save the DIJ Repository object into your instance variable
            this.repository = repository;
        }

        /***
         * Index Action
         **/
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            if(!ModelState.IsValid) { return View(); }

            //TODO: Store the player in the repository
            this.repository.Player = player;
           

            return RedirectToAction("Spin");
        }

        /***
         * Spin Action
         **/       
        public IActionResult Spin() //DON'T pass player info, get from repository
        {
            //TODO - Change the line below: create a new Spin with the player from the repository
            Spin spin = new Spin { Player = repository.Player};

            //TODO - Change the line below: get the Player's current balance from the repository
            currentBalance = repository.Player.Balance;

            /**
             * GAME PLAY LOGIC TODOs
             *   1) See if the Player has enough $ to play
             *      - if balance is less than $0.50, go to LuckList View
             *      - else, charge to play and go on to step 2
             *        
             *   2) Check if the Player's Spin is a winner
             *       - if so, increase the balance by $1
             *       - go onto step 3
             * 
             *   3) Update the repository with the new Spin, balance and Player info
             *       - Add a new SpinBalance record for this Spin
             *       - Update the Player object with the current balance 
             *       - go to the Spin View
             */


            //TODO: Step 1
            if (currentBalance < 0.50m)
            {
                return RedirectToAction ("LuckList");
            }

            {
                currentBalance -= 0.50m;
            }

            if (spin.IsWinning)
            {
                currentBalance += 1.00m;
            }

            repository.AddSpinBalance(spin, currentBalance);
            spin.Player.Balance = currentBalance;


            
            //TODO: Step 2
            


            //TODO: Step 3


            return View("Spin", spin);
        }

        /***
         * ListSpins Action
         **/
        [HttpGet]
        public IActionResult LuckList()
        {
            //TODO: Pass the repository's SpinBalances list and Player as a new LuckList to the View
            return View(new LuckList
            {
                SpinBalances = repository.SpinBalances,
                FirstName = repository.Player.FirstName
            });
        }

    }
}

