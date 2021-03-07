using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeroService : IHeroService
{
    public IHero Hero { get; set; } = new CommonHero();


}
