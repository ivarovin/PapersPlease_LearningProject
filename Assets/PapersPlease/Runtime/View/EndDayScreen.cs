﻿using System.Threading.Tasks;
using PapersPlease.Runtime.Controller;
using PapersPlease.Runtime.Model;
using UnityEngine;

namespace PapersPlease.Runtime.View
{
    public class EndDayScreen : MonoBehaviour, ExpensesReport
    {
        async Task ExpensesReport.OfDay(int day, EconomicBalance balance)
        {
            gameObject.SetActive(true);
        }
    }
}