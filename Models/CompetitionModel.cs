using dblaba.Database;
using dblaba.BaseModels;
using System.Collections.Generic;

namespace dblaba.Models;

public class CompetitionsModel {
    public List<Competition> Competitions { get; }

    public CompetitionsModel() {
        Competitions = new(QueryComposer.JoinCompetitions());

        for (int i = 0; i < Competitions.Count; i++) {
            Competitions[i].Index = i;
        }
    }
};
