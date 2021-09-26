// PieceworkWorker.cs
//         Title: IncInc Payroll (Piecework)
// Last Modified: Sept 26 2020
//    Written By: Tyler Henry 
// Adapted from PieceworkWorker by Kyle Chapman, September 2019
// 
// This is a class representing individual worker objects. Each stores
// their own name and number of messages and the class methods allow for
// calculation of the worker's pay and for updating of shared summary
// values. Name and messages are received as strings.
// This is being used as part of a piecework payroll application.

// This is currently incomplete; note the four comment blocks
// below that begin with "TO DO"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab1_TylerHenry // Ensure this namespace matches your own
{
    class PieceworkWorker
    {

        #region "Variable declarations"

        // Instance variables
        private string employeeName;
        private int employeeMessages;
        private decimal employeePay;

        private bool isValid = true;

        // Shared class variables
        private static int overallNumberOfEmployees;
        private static int overallMessages;
        private static decimal overallPayroll;
        private static decimal averagePay;

        #endregion

        #region "Constructors"

        /// <summary>
        /// PieceworkWorker constructor: accepts a worker's name and number of
        /// messages, sets and calculates values as appropriate.
        /// </summary>
        /// <param name="nameValue">the worker's name</param>
        /// <param name="messageValue">a worker's number of messages sent</param>
        public PieceworkWorker(string nameValue, string messagesValue)
        {
            // Validate and set the worker's name
            this.Name = nameValue;
            // Validate Validate and set the worker's number of messages
           
            this.Messages = messagesValue;
            
            
            // Calculcate the worker's pay and update all summary values
            findPay();
        }

        /// <summary>
        /// PieceworkWorker constructor: empty constructor used strictly for inheritance and instantiation
        /// </summary>
        public PieceworkWorker()
        {

        }

        #endregion

        #region "Class methods"

        /// <summary>
        /// Currently called in the constructor, the findPay() method is
        /// used to calculate a worker's pay using threshold values to
        /// change how much a worker is paid per message. This also updates
        /// all summary values.
        /// </summary>
        private void findPay()
        {
           //If worker name and messages are valid
            if(isValid)
            {
                //Calculate worker pay dependsing on number of messages sent
                if (employeeMessages > 0 && employeeMessages < 1250)
                {
                    employeePay = (decimal)(employeeMessages * 0.02);
                }
                else if (employeeMessages > 1249 && employeeMessages < 2500)
                {
                    employeePay = (decimal)(employeeMessages * 0.024);
                }
                else if (employeeMessages > 2499 && employeeMessages < 3750)
                {
                    employeePay = (decimal)(employeeMessages * 0.028);
                }
                else if (employeeMessages > 3749 && employeeMessages < 5000)
                {
                    employeePay = (decimal)(employeeMessages * 0.034);
                }
                else if (employeeMessages > 4999)
                {
                    employeePay = (decimal)(employeeMessages * 0.04);
                }

                // Increment all shared summary values
                overallNumberOfEmployees++;
                overallMessages += employeeMessages;
                overallPayroll += employeePay;
            }

        }

        #endregion

        #region "Property Procedures"

        /// <summary>
        /// Gets and sets a worker's name
        /// </summary>
        /// <returns>an employee's name</returns>
        public string Name
        {
            get
            {
                //returns employee name
                return employeeName;
            }
            set
            {
                //if employee name is empty
                if (value == "")
                {
                    //Inform user of error and set isValid to false
                    MessageBox.Show("Please enter a worker name");
                    isValid = false;
                }

                //set employee name to value
                employeeName = value;
            }
        }

        /// <summary>
        /// Gets and sets the number of messages sent by a worker
        /// </summary>
        /// <returns>an employee's number of messages</returns>
        public string Messages
        {
            get
            {
                //Return employeeMessages
                return employeeMessages.ToString();
            }
            set
            {
                //Const declartion
                const decimal MinimumMessages = 1;
                

                // If the messages sent are not an int, the worker is not valid
                if (!int.TryParse(value, out employeeMessages))
                {
                    MessageBox.Show("Please enter the worker's messages sent as a numeric value.");
                    isValid = false;
                }
                // If the messages sent are less then 1, the worker is not valid
                else if (employeeMessages < MinimumMessages)
                {
                    MessageBox.Show("The worker needs to of sent at least " + MinimumMessages.ToString() + " message");
                    isValid = false;
                }
            }
        }

        /// <summary>
        /// Gets the worker's pay
        /// </summary>
        /// <returns>a worker's pay</returns>
        public decimal Pay
        {
            get
            {
                return Math.Round(employeePay,2);
            }
        }

        /// <summary>
        /// Gets the overall total pay among all workers
        /// </summary>
        /// <returns>the overall total pay among all workers</returns>
        public static decimal TotalPay
        {
            get
            {
                return Math.Round(overallPayroll,2);
            }
        }

        /// <summary>
        /// Gets the overall number of workers
        /// </summary>
        /// <returns>the overall number of workers</returns>
        public static int TotalWorkers
        {
            get
            {
                return overallNumberOfEmployees;
            }
        }

        /// <summary>
        /// Gets the overall number of messages sent
        /// </summary>
        /// <returns>the overall number of messages sent</returns>
        public static int TotalMessages
        {
            get
            {
                return overallMessages;
            }
        }

        /// <summary>
        /// Calculates and returns an average pay among all workers
        /// </summary>
        /// <returns>the average pay among all workers</returns>
        public static decimal AveragePay
        {
            get
            {
                //Calculate average pay
                averagePay = overallPayroll / overallNumberOfEmployees;

                //Return averagePay rounded to 2 decimal places
                return Math.Round(averagePay,2);
            }
        }

        #endregion

    }
}
