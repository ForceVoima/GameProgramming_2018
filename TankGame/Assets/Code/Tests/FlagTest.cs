﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TankGame;

namespace TankGame.Testing
{
    public class FlagTest
    {
        [Test]
        public void FlagTestCreateEnemyAndPlayerMask()
        {
            int playerLayer = LayerMask.NameToLayer("Player"); //8
            int enemyLayer = LayerMask.NameToLayer("Enemy"); //9

            int mask = Flags.CreateMask(playerLayer, enemyLayer);
            int validMask = LayerMask.GetMask("Player", "Enemy");

            Assert.AreEqual(mask, validMask);
        }
    }
}