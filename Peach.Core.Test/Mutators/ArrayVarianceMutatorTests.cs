﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Peach.Core;
using Peach.Core.Dom;
using Peach.Core.Analyzers;
using Peach.Core.IO;

namespace Peach.Core.Test.Mutators
{
    [TestFixture]
    class ArrayVarianceMutatorTests
    {
        byte[] testValue;
        List<byte[]> listVals = new List<byte[]>();

        [Test]
        public void Test1()
        {
            // standard test -- change the length of the array to count - N to count + N (default is 50)
            // 01234 -> [0, 01, 012, 0123, 01234, 012344, 0123444, ... len(55)]

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<Peach>" +
                "   <DataModel name=\"TheDataModel\">" +
                "       <String name=\"a0\" value=\"0\" maxOccurs=\"100\"/>" +
                "   </DataModel>" +

                "   <StateModel name=\"TheState\" initialState=\"Initial\">" +
                "       <State name=\"Initial\">" +
                "           <Action type=\"output\">" +
                "               <DataModel ref=\"TheDataModel\"/>" +
                "           </Action>" +
                "       </State>" +
                "   </StateModel>" +

                "   <Test name=\"TheTest\">" +
                "       <StateModel ref=\"TheState\"/>" +
                "       <Publisher class=\"Stdout\"/>" +
                "   </Test>" +

                "   <Run name=\"DefaultRun\">" +
                "       <Test ref=\"TheTest\"/>" +
                "   </Run>" +
                "</Peach>";

            PitParser parser = new PitParser();

            Dom.Dom dom = parser.asParser(new Dictionary<string, string>(), new MemoryStream(ASCIIEncoding.ASCII.GetBytes(xml)));

            var myArray = (Dom.Array)dom.runs[0].tests[0].stateModel.initialState.actions[0].dataModel[0];
            myArray.origionalElement = myArray[0];
            myArray.hasExpanded = true;
            myArray.Add(new Dom.String("a1", "1"));
            myArray.Add(new Dom.String("a2", "2"));
            myArray.Add(new Dom.String("a3", "3"));
            myArray.Add(new Dom.String("a4", "4"));

            RunConfiguration config = new RunConfiguration();

            Dom.Action.Finished += new ActionFinishedEventHandler(Action_FinishedTest);

            Engine e = new Engine(null);
            e.config = config;
            e.startFuzzing(dom, config);

            // verify values
            Assert.IsTrue(listVals.Count == 57);

            // reset
            testValue = null;
            listVals.Clear();
        }

        [Test]
        public void Test2()
        {
            // standard test -- change the length of the array to count - N to count + N (N = 5)
            // 01234 -> [0, 01, 012, 0123, 01234, 012344, 0123444, 01234444, 012344444, 0123444444]

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<Peach>" +
                "   <DataModel name=\"TheDataModel\">" +
                "       <String name=\"a0\" value=\"0\" maxOccurs=\"100\">" +
                "           <Hint name=\"ArrayVarianceMutator-N\" value=\"5\"/>" +
                "       </String>" +
                "   </DataModel>" +

                "   <StateModel name=\"TheState\" initialState=\"Initial\">" +
                "       <State name=\"Initial\">" +
                "           <Action type=\"output\">" +
                "               <DataModel ref=\"TheDataModel\"/>" +
                "           </Action>" +
                "       </State>" +
                "   </StateModel>" +

                "   <Test name=\"TheTest\">" +
                "       <StateModel ref=\"TheState\"/>" +
                "       <Publisher class=\"Stdout\"/>" +
                "   </Test>" +

                "   <Run name=\"DefaultRun\">" +
                "       <Test ref=\"TheTest\"/>" +
                "   </Run>" +
                "</Peach>";

            PitParser parser = new PitParser();

            Dom.Dom dom = parser.asParser(new Dictionary<string, string>(), new MemoryStream(ASCIIEncoding.ASCII.GetBytes(xml)));

            var myArray = (Dom.Array)dom.runs[0].tests[0].stateModel.initialState.actions[0].dataModel[0];
            myArray.origionalElement = myArray[0];
            myArray.hasExpanded = true;
            myArray.Add(new Dom.String("a1", "1"));
            myArray.Add(new Dom.String("a2", "2"));
            myArray.Add(new Dom.String("a3", "3"));
            myArray.Add(new Dom.String("a4", "4"));

            RunConfiguration config = new RunConfiguration();

            Dom.Action.Finished += new ActionFinishedEventHandler(Action_FinishedTest);

            Engine e = new Engine(null);
            e.config = config;
            e.startFuzzing(dom, config);

            // verify values
            Assert.IsTrue(listVals.Count == 12);
            Assert.AreEqual(listVals[1], new byte[0]);
            Assert.AreEqual(listVals[2], new byte[] { (byte)('0') });
            Assert.AreEqual(listVals[3], new byte[] { (byte)('0'), (byte)('1') });
            Assert.AreEqual(listVals[4], new byte[] { (byte)('0'), (byte)('1'), (byte)('2') });
            Assert.AreEqual(listVals[5], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3') });
            Assert.AreEqual(listVals[6], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4') });
            Assert.AreEqual(listVals[7], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4'), (byte)('4') });
            Assert.AreEqual(listVals[8], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4'), (byte)('4'), (byte)('4') });
            Assert.AreEqual(listVals[9], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4') });
            Assert.AreEqual(listVals[10], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4') });
            Assert.AreEqual(listVals[11], new byte[] { (byte)('0'), (byte)('1'), (byte)('2'), (byte)('3'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4'), (byte)('4') });

            // reset
            testValue = null;
            listVals.Clear();
        }

        void Action_FinishedTest(Dom.Action action)
        {
            testValue = action.dataModel[0].Value.Value;
            listVals.Add(testValue);
        }
    }
}

// end
