using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHeroService
{
    IHero Hero { get;set; }
    void ConfigureForHeroId(string heroID);
}
