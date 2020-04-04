using System;
using System.Collections.Generic;
using System.Text;

namespace Deckbuilder.Core.Enums
{
	public enum ActionType
	{
		//Remove a card from the game
		Banish,
		//Send card from hand to discard pile
		Discard,
		//Draw a card from top of draw pile into hand
		Draw,
		//View the top card of draw pile
		Peek,
		//Place the top card of deck into discard
		Cycle,
		//Gain resources
		Gain,
		//Lose resources
		Lose,
		//Send enemy fortification or outpost to opponents discard without paying damage cost
		Destroy,
		//Remove target neutral monster and collect bounty without paying damage cost
		Vanquish,
		//Get non-monster card from store without paying the purchase price
		Acquire,
		//Transform a card to one of its upgradable forms and return to your discard
		Upgrade,
		//Generate card and place in opponents discard
		Curse,
		//Generate card and place in your discard
		Spawn,
		//Place event trigger on opponent
		Hex,
		//Place event trigger on self
		Charm,
		//Action representing a list of child actions
		And,
		//Action representing a choice of child actions
		Or,
	}
}
