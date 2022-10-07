using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChargersSearch;

namespace ChargersSearchTest;


[TestClass]
public class ChargerSearchTests
{

    List<Charger> dataStore = new List<Charger>();

    // initialise test data
    public ChargerSearchTests()
    {
        dataStore.Add(new Charger() {name = "Zappi Single Phase", type = 1, phase = PhaseType.Single, tethered = true});
        dataStore.Add(new Charger() {name = "Zappi Three Phase", type = 1, phase = PhaseType.Three, tethered = true});
        dataStore.Add(new Charger() {name = "Wallbox Single Phase", type = 2, phase = PhaseType.Single, tethered = true});
        dataStore.Add(new Charger() {name = "Wallbox Single Phase Untethered", type = 2, phase = PhaseType.Single, tethered = false});        
        dataStore.Add(new Charger() {name = "ABB", type = 2, phase = PhaseType.Three, tethered = true});        
    }


    //TODO paramaterise test cases
    [TestMethod]
    public void ChargersSearch_Should_Return_Chargers_Matching_Search_Params()
    {

        var chargersSearch = new ChargerSearch(dataStore);
        var chargerResults = chargersSearch.Search(2, PhaseType.Single, true);

        Assert.AreEqual(1, chargerResults.Count());
    }

    [TestMethod]
    public void ChargersSearch_Should_Return_Chargers_Matching_Search_Params2()
    {

        var chargersSearch = new ChargerSearch(dataStore);
        var chargerResults = chargersSearch.Search(2, PhaseType.Single, false);

        Assert.AreEqual(1, chargerResults.Count());
    }

    [TestMethod]
    public void ChargersSearch_Should_Return_Chargers_Matching_Search_Params3()
    {

        var chargersSearch = new ChargerSearch(dataStore);
        var chargerResults = chargersSearch.Search(2, PhaseType.Three, false);

        Assert.AreEqual(0, chargerResults.Count());
    }

    [TestMethod]
    public void ChargersSearch_Should_Support_Unknown_Phase_Type()
    {
        var chargersSearch = new ChargerSearch(dataStore);
        var chargerResults = chargersSearch.Search(2, PhaseType.Unknown, true);

        Assert.AreEqual(2, chargerResults.Count());
    }
}