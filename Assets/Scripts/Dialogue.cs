using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private int playingAs, boss, set, toShow;
    [SerializeField] private bool monologue;
    [SerializeField] private GameObject box;
    [SerializeField] private Text display, speaking;
    //[SerializeField] private List<Image> playerProfiles = new List<Image>(), bossProfiles = new List<Image>();
    [SerializeField] private Player player;
    [SerializeField] private StageProgression progressor;

    void Start()
    {
        player = FindObjectOfType<Player>();
        progressor = FindObjectOfType<StageProgression>();

        playingAs = player.PlayingAs();

        if (monologue) RunDialogue(0, 0);
        else box.SetActive(false);
    }

    void Update()
    {
        if (box.active)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                toShow++;
            }

            switch (set)
            {
                case 0: //Player character's beginning thoughts
                    switch (playingAs)
                    {
                        case 0:
                            switch (toShow)
                            {
                                case 0:
                                    speaking.text = "";
                                    display.text = "Let's see here... map, check. Scarscar, check. Bullet Charm...";
                                    break;
                                case 1:
                                    display.text = "Eh? Where did I...?";
                                    break;
                                case 2:
                                    display.text = "Oh, there it is. Check! Off I go, then.";
                                    break;
                                case 3:
                                    display.text = "I just hope I make it back in one piece...";
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 1:
                            switch (toShow)
                            {
                                case 0:
                                    speaking.text = "";
                                    display.text = "It should be the water, right? None of my tools are broken.";
                                    break;
                                case 1:
                                    display.text = "If it's not just affecting my garden, but the entire village...";
                                    break;
                                case 2:
                                    display.text = "You know what? Forget that.";
                                    break;
                                case 3:
                                    display.text = "It'll all work out. It has to.";
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 2:
                            switch (toShow)
                            {
                                case 0:
                                    speaking.text = "";
                                    display.text = "Alright. Here we go.";
                                    break;
                                case 1:
                                    display.text = "Just have to contain it at its source.";
                                    break;
                                case 2:
                                    display.text = "...";
                                    break;
                                case 3:
                                    display.text = "I hate this river.";
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        default:
                            box.SetActive(false);
                            progressor.SetDialogue(false);
                            break;
                    }
                    break;
                case 1: // Pre-bossfight dialogue
                    switch (playingAs)
                    {
                        case 0:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "Oh, uh... hi?";
                                            break;
                                        case 1:
                                            speaking.text = "METTO";
                                            display.text = "Why is a darner on Coridi grounds?";
                                            break;
                                        case 2:
                                            display.text = "Don't bother answering. I know your kind.";
                                            break;
                                        case 3:
                                            speaking.text = "ACE";
                                            display.text = "I was kicked out of the Creed the moment I left the water!";
                                            break;
                                        case 4:
                                            display.text = "I don't want anything to do with them!";
                                            break;
                                        case 5:
                                            speaking.text = "METTO";
                                            display.text = "And why should I believe you?";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "WI VIl";
                                            display.text = "Thought you could take down my guardsroach, eh?";
                                            break;
                                        case 1:
                                            speaking.text = "ACE";
                                            display.text = "I wasn't trying to hurt him.";
                                            break;
                                        case 2:
                                            speaking.text = "WI VIL";
                                            display.text = "A statement like that from a darner? Bold.";
                                            break;
                                        case 3:
                                            display.text = "If your kind are going to drag us all into the afterlife...";
                                            break;
                                        case 4:
                                            display.text = "We might as well take one of you down with us.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "Hello?";
                                            break;
                                        case 1:
                                            speaking.text = "JUNP";
                                            display.text = "GREAT SKIES IT'S A DARNER-";
                                            break;
                                        case 2:
                                            speaking.text = "ACE";
                                            display.text = "I... B... Wait!";
                                            break;
                                        case 3:
                                            display.text = "Hold on! I'm not trying to...";
                                            break;
                                        case 4:
                                            speaking.text = "JUNP";
                                            display.text = "Come no closer, vile creature.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "So bold, to fly straight into the capital. To assault civilians...";
                                            break;
                                        case 1:
                                            display.text = "...to disrupt the day-to-day about the Hive...";
                                            break;
                                        case 2:
                                            display.text = "How did you not attract the attention of the guards?";
                                            break;
                                        case 3:
                                            speaking.text = "ACE";
                                            display.text = "Beats me.";
                                            break;
                                        case 4:
                                            display.text = "Look, I'm just trying to find out why the river's foul.";
                                            break;
                                        case 5:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "Did you not consider going AROUND Hexad?";
                                            break;
                                        case 6:
                                            display.text = "Gah! Why are the guards so useless?";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "May I... have a word, Your Highness?";
                                            break;
                                        case 1:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "There is nothing to say.";
                                            break;
                                        case 2:
                                            speaking.text = "ACE";
                                            display.text = "Please. It's for the well-being of the entire island.";
                                            break;
                                        case 3:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "You have challenged the entire royal guard, have you not?";
                                            break;
                                        case 4:
                                            speaking.text = "ACE";
                                            display.text = "It was just self-defense. I didn't mean to hurt anyone.";
                                            break;
                                        case 5:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "A likely story.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "";
                                            display.text = "You.";
                                            break;
                                        case 1:
                                            speaking.text = "FLARE";
                                            display.text = "I thought we made it clear you are not welcome.";
                                            break;
                                        case 2:
                                            speaking.text = "ACE";
                                            display.text = "I know. The circumstances of why I'm here are...";
                                            break;
                                        case 3:
                                            display.text = "... unfortunate, to say the least.";
                                            break;
                                        case 4:
                                            speaking.text = "FLARE";
                                            display.text = "Ah, that! Of course.";
                                            break;
                                        case 5:
                                            display.text = "Mark my words, stain.";
                                            break;
                                        case 6:
                                            display.text = "Returning to the Creed's grounds will be your last mistake.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Why, hello there!";
                                            break;
                                        case 1:
                                            display.text = "We don't get visitors often, save for the Creed darners...";
                                            break;
                                        case 2:
                                            display.text = "And no, I'm not going to eat you.";
                                            break;
                                        case 3:
                                            speaking.text = "ACE";
                                            display.text = "... I...";
                                            break;
                                        case 4:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Seeing a new face every once in a while is a good thing.";
                                            break;
                                        case 5:
                                            display.text = "Now, since you came all this way...";
                                            break;
                                        case 6:
                                            display.text = "Shall we dance?";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 1:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "You must be her.";
                                            break;
                                        case 1:
                                            display.text = "I've heard some pretty good things about you.";
                                            break;
                                        case 2:
                                            speaking.text = "METTO";
                                            display.text = "Did further downstream seriously come up with legends...";
                                            break;
                                        case 3:
                                            display.text = "...about LIVING INSECTS?!";
                                            break;
                                        case 4:
                                            speaking.text = "MAY";
                                            display.text = "Yes and no.";
                                            break;
                                        case 5:
                                            speaking.text = "METTO";
                                            display.text = "Ugh...";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "WI VIL";
                                            display.text = "Well, look who it is!";
                                            break;
                                        case 1:
                                            speaking.text = "MAY";
                                            display.text = "What do you mean by that?";
                                            break;
                                        case 2:
                                            speaking.text = "WI VIL";
                                            display.text = "Eh, forget it. It doesn't really matter.";
                                            break;
                                        case 3:
                                            display.text = "Still, you shouldn't be here. Not now, not ever.";
                                            break;
                                        case 4:
                                            speaking.text = "MAY";
                                            display.text = "Don't worry. I'll be out of your way in a moment.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "Are you alright?";
                                            break;
                                        case 1:
                                            speaking.text = "JUNP";
                                            display.text = "...whuh...?";
                                            break;
                                        case 2:
                                            speaking.text = "MAY";
                                            display.text = "Have you been getting enough sleep lately?";
                                            break;
                                        case 3:
                                            speaking.text = "JUNP";
                                            display.text = "There hasn't been much activity, so I...";
                                            break;
                                        case 4:
                                            display.text = "WAIT HOW DO I KNOW THIS ISN'T A TRAP?!";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "Halt, outsider.";
                                            break;
                                        case 1:
                                            display.text = "If the guards were not so incompetent, you would already...";
                                            break;
                                        case 2:
                                            speaking.text = "MAY";
                                            display.text = "Wow, you sure seem cheerful!";
                                            break;
                                        case 3:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "... have been detained.";
                                            break;
                                        case 4:
                                            display.text = "Stand down, near-bug, and do not resist.";
                                            break;
                                        case 5:
                                            speaking.text = "MAY";
                                            display.text = "Maybe I would've if you hadn't antagonized me.";
                                            break;
                                        case 6:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "Silence!";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Outsider.";
                                            break;
                                        case 1:
                                            speaking.text = "MAY";
                                            display.text = "Your Majesty.";
                                            break;
                                        case 2:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "What is your purpose in my kingdom?";
                                            break;
                                        case 3:
                                            speaking.text = "MAY";
                                            display.text = "The river has gone foul. Your Hive is merely a detour.";
                                            break;
                                        case 4:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Yet, you challenged the entire royal guard and succeeded.";
                                            break;
                                        case 5:
                                            display.text = "How peculiar.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "So you must be the cult leader Ace warned me about.";
                                            break;
                                        case 1:
                                            speaking.text = "FLARE";
                                            display.text = "You know that demonic thing?";
                                            break;
                                        case 2:
                                            display.text = "Did she tell you about her failed cleansing?";
                                            break;
                                        case 3:
                                            display.text = "Some mutation kept her from becoming whole again.";
                                            break;
                                        case 4:
                                            speaking.text = "MAY";
                                            display.text = "It's not a mutation. It's just who they are.";
                                            break;
                                        case 5:
                                            speaking.text = "FLARE";
                                            display.text = "Defending that threat will be your last mistake.";
                                            break;
                                        case 6:
                                            speaking.text = "MAY";
                                            display.text = "Well. So much for being civil.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Why, hello there!";
                                            break;
                                        case 1:
                                            speaking.text = "MAY";
                                            display.text = "!";
                                            break;
                                        case 2:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Don't worry, I'm not going to eat you.";
                                            break;
                                        case 3:
                                            display.text = "It'd be wrong to do that to anything capable of higher thought.";
                                            break;
                                        case 4:
                                            display.text = "Besides, you're very cute.";
                                            break;
                                        case 5:
                                            speaking.text = "MAY";
                                            display.text = "Make another move and I'll shoot!";
                                            break;
                                        case 6:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Go right ahead. Whatever makes you feel comfortable.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 2:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "KERA PES";
                                            display.text = "Whoa, whoa, whoa, where did YOU come from?!";
                                            break;
                                        case 1:
                                            speaking.text = "METTO";
                                            display.text = "Is this your first time here? I don't blame you for freaking out.";
                                            break;
                                        case 2:
                                            speaking.text = "KERA PES";
                                            display.text = "I have business to attend to, roach.";
                                            break;
                                        case 3:
                                            display.text = "I suggest you get out of my way before I have to plow you over.";
                                            break;
                                        case 4:
                                            speaking.text = "METTO";
                                            display.text = "Plow me over?";
                                            break;
                                        case 5:
                                            display.text = "We'll see about that, spider hunter.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "KERA PES";
                                            display.text = "Hey! Long time, no see.";
                                            break;
                                        case 1:
                                            speaking.text = "WI VIL";
                                            display.text = "So, ya still up for a rematch?";
                                            break;
                                        case 2:
                                            speaking.text = "KERA PES";
                                            display.text = "'Course I am, old man!";
                                            break;
                                        case 3:
                                            speaking.text = "WI VIL";
                                            display.text = "And with zero out of five! This'll be great!";
                                            break;
                                        case 4:
                                            speaking.text = "KERA PES";
                                            display.text = "Wouldn't want to keep you waiting.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "JUNP";
                                            display.text = "...halt.";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "Why?";
                                            break;
                                        case 2:
                                            speaking.text = "JUNP";
                                            display.text = "...you're intr-";
                                            break;
                                        case 3:
                                            display.text = "Is that a spear holster.";
                                            break;
                                        case 4:
                                            speaking.text = "KERA PES";
                                            display.text = "So what if it is? I had to leave my spears at home.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "Who are you, and what business do you have in Hexad?";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "I'm just following the river.";
                                            break;
                                        case 2:
                                            display.text = "The water's real bad all the way down at Ridgeside.";
                                            break;
                                        case 3:
                                            display.text = "Trying to figure out why that is.";
                                            break;
                                        case 4:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "And yet, you felt the need to storm the capital?";
                                            break;
                                        case 5:
                                            display.text = "Do you think yourself to be a hero? Then die like one!";
                                            break;
                                        case 6:
                                            speaking.text = "KERA PES";
                                            display.text = "... and I thought I was ornery.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Outsider. State your business in my Hive.";
                                            break;
                                        case 1:
                                            display.text = "...";
                                            break;
                                        case 2:
                                            display.text = "You do not seem to be thrilled at this moment.";
                                            break;
                                        case 3:
                                            speaking.text = "KERA PES";
                                            display.text = "Honestly, I'd rather be around grubs right now.";
                                            break;
                                        case 4:
                                            display.text = "But I can't do that while our closest water source is polluted.";
                                            break;
                                        case 5:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "If you truly wish as such, so be it.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "FLARE";
                                            display.text = "I have heard many things about you.";
                                            break;
                                        case 1:
                                            display.text = "The only aggressive Ridgeside bug.";
                                            break;
                                        case 2:
                                            speaking.text = "KERA PES";
                                            display.text = "Don't get me started.";
                                            break;
                                        case 3:
                                            speaking.text = "FLARE";
                                            display.text = "Why not?";
                                            break;
                                        case 4:
                                            speaking.text = "KERA PES";
                                            display.text = "You know why I'm here, right?";
                                            break;
                                        case 5:
                                            display.text = "The water here is much clearer than downstream.";
                                            break;
                                        case 6:
                                            speaking.text = "FLARE";
                                            display.text = "And how does this concern me?";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Why, hello there!";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "... Great skies.";
                                            break;
                                        case 2:
                                            speaking.text = "SPECSHOT";
                                            display.text = "There's no such need to say such things. Really.";
                                            break;
                                        case 3:
                                            speaking.text = "KERA PES";
                                            display.text = "Your kind are more threatening than spiders!";
                                            break;
                                        case 4:
                                            display.text = "Dying to a Sixwings is by far the worst way to go out!";
                                            break;
                                        case 5:
                                            speaking.text = "SPECSHOT";
                                            display.text = "I'm not going to eat you. That'd be rude.";
                                            break;
                                        case 6:
                                            speaking.text = "KERA PES";
                                            display.text = "Oh, you want to see rude? I'll show you rude.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        default:
                            box.SetActive(false);
                            progressor.SetDialogue(false);
                            break;
                    }
                    break;
                case 2: // Post-bossfight dialogue
                    switch (playingAs)
                    {
                        case 0:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "So...";
                                            break;
                                        case 1:
                                            speaking.text = "METTO";
                                            display.text = "I see now. You really aren't.";
                                            break;
                                        case 2:
                                            display.text = "I don't want the hemolymph of a Ridgeside insect on my claws.";
                                            break;
                                        case 3:
                                            display.text = "Just...";
                                            break;
                                        case 4:
                                            display.text = "Just go.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "Maybe you should've at least, you know...";
                                            break;
                                        case 1:
                                            display.text = "... checked who was in front of you before attacking?";
                                            break;
                                        case 2:
                                            speaking.text = "WI VIL";
                                            display.text = "...";
                                            break;
                                        case 3:
                                            display.text = "Yeah, that checks out.";
                                            break;
                                        case 4:
                                            display.text = "Sorry 'bout that, bud! Carry on.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "JUNP";
                                            display.text = "Okay, okay! You win.";
                                            break;
                                        case 1:
                                            display.text = "There was supposed to be more beyond this point, but there isn't.";
                                            break;
                                        case 2:
                                            speaking.text = "?????";
                                            display.text = "Now I get why Rin was cut from EoSD. Time constraints really are stupid.";
                                            break;
                                        case 3:
                                            display.text = "Well, maybe check Steam in a few years. This'll probably be finished by then.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            GameManager.UnlockChainedMemories();
                                            break;
                                    }
                                    /*switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "Will you listen now?";
                                            break;
                                        case 1:
                                            speaking.text = "JUNP";
                                            display.text = "Oh, wait, it's you.";
                                            break;
                                        case 2:
                                            display.text = "I'm so sorry!";
                                            break;
                                        case 3:
                                            display.text = "I'll guide you wherever you need.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "You done? Cool.";
                                            break;
                                        case 1:
                                            display.text = "Also, the Rushing Worm cuts straight through Hexad.";
                                            break;
                                        case 2:
                                            display.text = "Kinda hard to go around the city when... you know...";
                                            break;
                                        case 3:
                                            speaking.text = "DUKE ACULEUS";
                                            display.text = "I suppose.";
                                            break;
                                        case 4:
                                            display.text = "Now get out of my sight.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACE";
                                            display.text = "Okay, do you know anything about the river's pollution?";
                                            break;
                                        case 1:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Perhaps, perhaps not.";
                                            break;
                                        case 2:
                                            display.text = "Yet, it is not due to the activities of my kingdom.";
                                            break;
                                        case 3:
                                            display.text = "Seek elsewhere, strange darner of Ridgeside.";
                                            break;
                                        case 4:
                                            speaking.text = "ACE";
                                            display.text = "Thank you, Your Majesty.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    if (GameManager.GetDifficulty() == 4 || ((GameManager.GetDifficulty() == 2 || GameManager.GetDifficulty() == 3) && Player.GetHits() == 0))
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "FLARE";
                                                display.text = "Perhaps I underestimated you.";
                                                break;
                                            case 1:
                                                speaking.text = "ACE";
                                                display.text = "Yeah, and?";
                                                break;
                                            case 2:
                                                speaking.text = "FLARE";
                                                display.text = "Might you be capable of surviving the wrath of the gods?";
                                                break;
                                            case 3:
                                                speaking.text = "ACE";
                                                display.text = "W- what does that mean?!";
                                                break;
                                            case 4:
                                                speaking.text = "FLARE";
                                                display.text = "If you feel you are ready, simply ascend the peak.";
                                                break;
                                            case 5:
                                                display.text = "Perhaps They can free the island of another burden.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "FLARE";
                                                display.text = "The stain lives to see another day. How disappointing.";
                                                break;
                                            case 1:
                                                speaking.text = "ACE";
                                                display.text = "I have been ever since you tried to perform an exorcism.";
                                                break;
                                            case 2:
                                                speaking.text = "FLARE";
                                                display.text = "We WILL find you and finish what we started.";
                                                break;
                                            case 3:
                                                speaking.text = "ACE";
                                                display.text = "Okay, but at least stop polluting the water.";
                                                break;
                                            case 4:
                                                display.text = "The whole island might riot if you don't.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Nothing like fulfilling an age-old tradition!";
                                            break;
                                        case 1:
                                            speaking.text = "ACE";
                                            display.text = "You... huh?";
                                            break;
                                        case 2:
                                            display.text = "Bullet Charm fights are tradition?";
                                            break;
                                        case 3:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Always have been, little traveler.";
                                            break;
                                        case 4:
                                            display.text = "You have my respect...";
                                            break;
                                        case 5:
                                            display.text = "... and utmost gratitude.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }*/
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 1:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "Okay, but I get where the stories about you come from.";
                                            break;
                                        case 1:
                                            speaking.text = "METTO";
                                            display.text = "Why.";
                                            break;
                                        case 2:
                                            speaking.text = "MAY";
                                            display.text = "Have you always been able to play with the fabric of reality?";
                                            break;
                                        case 3:
                                            display.text = "You're good at it. Especially since it's so rare.";
                                            break;
                                        case 4:
                                            speaking.text = "METTO";
                                            display.text = "Yeah, okay, sure. Please leave already.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "I'll be out of your way now, as promised.";
                                            break;
                                        case 1:
                                            speaking.text = "WI VIL";
                                            display.text = "Actually, before you go...";
                                            break;
                                        case 2:
                                            display.text = "How did you get your patterns to look so cool?";
                                            break;
                                        case 3:
                                            display.text = "I wanna be able to do stuff like that.";
                                            break;
                                        case 4:
                                            speaking.text = "MAY";
                                            display.text = "It's kind of like how I put my overalls on. They just are.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "JUNP";
                                            display.text = "Okay, okay! You win.";
                                            break;
                                        case 1:
                                            display.text = "There was supposed to be more beyond this point, but there isn't.";
                                            break;
                                        case 2:
                                            speaking.text = "?????";
                                            display.text = "Now I get why Rin was cut from EoSD. Time constraints really are stupid.";
                                            break;
                                        case 3:
                                            display.text = "Well, maybe check Steam in a few years. This'll probably be finished by then.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            GameManager.UnlockChainedMemories();
                                            break;
                                    }
                                    /*switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "How could this have possibly been a trap?";
                                            break;
                                        case 1:
                                            display.text = "Ridgeside doesn't pick fights, silly.";
                                            break;
                                        case 2:
                                            speaking.text = "JUNP";
                                            display.text = "Sorry, Miss Gardener. How can I make it up to you?";
                                            break;
                                        case 3:
                                            speaking.text = "MAY";
                                            display.text = "No need. I can handle it.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "MAY";
                                            display.text = "Y'know, you remind me of someone.";
                                            break;
                                        case 1:
                                            speaking.text = "ACULEUS";
                                            display.text = "Do I, now?";
                                            break;
                                        case 2:
                                            display.text = "What does it matter to a near-bug like you?";
                                            break;
                                        case 3:
                                            speaking.text = "MAY";
                                            display.text = "You're still like him. Just not kid-friendly.";
                                            break;
                                        case 4:
                                            display.text = "I'll be on my way now. See you never!";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "You are... quite strong, for someone so small.";
                                            break;
                                        case 1:
                                            speaking.text = "MAY";
                                            display.text = "Thank you.";
                                            break;
                                        case 2:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Your trip through the hive was not your intention, correct?";
                                            break;
                                        case 3:
                                            speaking.text = "MAY";
                                            display.text = "It was not, Your Majesty.";
                                            break;
                                        case 4:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "Then, you had best be on your way.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    if (GameManager.GetDifficulty() == 4 || ((GameManager.GetDifficulty() == 2 || GameManager.GetDifficulty() == 3) && Player.GetHits() == 0))
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "MAY";
                                                display.text = "Okay, are you going to clear up the Rushing Worm now?";
                                                break;
                                            case 1:
                                                speaking.text = "FLARE";
                                                display.text = "Of course. And yet...";
                                                break;
                                            case 2:
                                                speaking.text = "MAY";
                                                display.text = "What?";
                                                break;
                                            case 3:
                                                speaking.text = "FLARE";
                                                display.text = "Heh. I see no reason why it should be a problem.";
                                                break;
                                            case 4:
                                                display.text = "If you feel you are ready, simply ascend the peak.";
                                                break;
                                            case 5:
                                                display.text = "Such a drake as you should have no issues against the gods.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "FLARE";
                                                display.text = "Tch... Leave my domain, and I will track her down.";
                                                break;
                                            case 1:
                                                display.text = "My darners will not stop until they eliminate that monster.";
                                                break;
                                            case 2:
                                                speaking.text = "MAY";
                                                display.text = "I don't care how many threats you make. Leave Ace alone.";
                                                break;
                                            case 3:
                                                display.text = "Oh, and you'd better clear up the Rushing Worm.";
                                                break;
                                            case 4:
                                                display.text = "It'd be a shame if something were to happen to you bugs.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Alright, you win.";
                                            break;
                                        case 1:
                                            speaking.text = "MAY";
                                            display.text = "So, you're not...";
                                            break;
                                        case 2:
                                            display.text = "I'm sorry. I don't know what came over me.";
                                            break;
                                        case 3:
                                            speaking.text = "SPECSHOT";
                                            display.text = "It's no big deal. Most newcomers freak out like that.";
                                            break;
                                        case 4:
                                            display.text = "Oh, and if you ever want to...";
                                            break;
                                        case 5:
                                            display.text = "Let's do this again sometime.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }*/
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        case 2:
                            switch (boss)
                            {
                                case 1:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "METTO";
                                            display.text = "Case in point.";
                                            break;
                                        case 1:
                                            display.text = "You're pretty tough, actually! I can't believe I doubted you.";
                                            break;
                                        case 2:
                                            speaking.text = "KERA PES";
                                            display.text = "Uh...";
                                            break;
                                        case 3:
                                            speaking.text = "METTO";
                                            display.text = "I'm giving you free passage through the rest of Coridi until sundown.";
                                            break;
                                        case 4:
                                            display.text = "Best of luck.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "WI VIL";
                                            display.text = "Still as strong as ever.";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "You were holding back! That wasn't a proper rematch!";
                                            break;
                                        case 2:
                                            speaking.text = "WI VIL";
                                            display.text = "Eh, it's fine. I haven't been feeling the greatest as of late.";
                                            break;
                                        case 3:
                                            display.text = "Weren't you off to beat up whoever polluted the river?";
                                            break;
                                        case 4:
                                            speaking.text = "KERA PES";
                                            display.text = "Oh, shoot! THAT'S what I was doing!";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "JUNP";
                                            display.text = "Okay, okay! You win.";
                                            break;
                                        case 1:
                                            display.text = "There was supposed to be more beyond this point, but there isn't.";
                                            break;
                                        case 2:
                                            speaking.text = "?????";
                                            display.text = "Now I get why Rin was cut from EoSD. Time constraints really are stupid.";
                                            break;
                                        case 3:
                                            display.text = "Well, maybe check Steam in a few years. This'll probably be finished by then.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            GameManager.UnlockChainedMemories();
                                            break;
                                    }
                                    /*switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "JUNP";
                                            display.text = "What do you need five spears at a single time for?";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "My job.";
                                            break;
                                        case 2:
                                            display.text = "Speaking of, you should probably take more breaks.";
                                            break;
                                        case 3:
                                            display.text = "You'll be more efficient and less sleep deprived if you do.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "ACULEUS";
                                            display.text = "Get. Out.";
                                            break;
                                        case 1:
                                            speaking.text = "KERA PES";
                                            display.text = "Nah. I don't think I will.";
                                            break;
                                        case 2:
                                            speaking.text = "";
                                            display.text = "...";
                                            break;
                                        case 3:
                                            speaking.text = "ACULEUS";
                                            display.text = "Hmph. So long as you are out of Hexad by sundown.";
                                            break;
                                        case 4:
                                            speaking.text = "KERA PES";
                                            display.text = "Now we're talking.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 5:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "KERA PES";
                                            display.text = "Why'd y'all have to build right above the river?";
                                            break;
                                        case 1:
                                            display.text = "This could've been avoided if the bars weren't there.";
                                            break;
                                        case 2:
                                            speaking.text = "QUEEN JASPER";
                                            display.text = "My kingdom has stood much longer than I have existed.";
                                            break;
                                        case 3:
                                            display.text = "You would have to ask the first wasps for answers.";
                                            break;
                                        case 4:
                                            display.text = "Run along now, prime guard of Ridgeside.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }
                                    break;
                                case 6:
                                    if (GameManager.GetDifficulty() == 4 || ((GameManager.GetDifficulty() == 2 || GameManager.GetDifficulty() == 3) && Player.GetHits() == 0))
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "FLARE";
                                                display.text = "I daresay you are almost as strong as Them.";
                                                break;
                                            case 1:
                                                speaking.text = "KERA PES";
                                                display.text = "As strong as who?";
                                                break;
                                            case 2:
                                                speaking.text = "FLARE";
                                                display.text = "Do you, perchance, not know of Them?";
                                                break;
                                            case 3:
                                                display.text = "Shameful, for one who supposedly dabbles in history.";
                                                break;
                                            case 4:
                                                speaking.text = "KERA PES";
                                                display.text = "Tell. Me. Already.";
                                                break;
                                            case 5:
                                                speaking.text = "FLARE";
                                                display.text = "Well, if you feel you are ready, simply ascend the peak.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (toShow)
                                        {
                                            case 0:
                                                speaking.text = "KERA PES";
                                                display.text = "You definitely have something to do with the pollution.";
                                                break;
                                            case 1:
                                                speaking.text = "FLARE";
                                                display.text = "So I have. What are you implying?";
                                                break;
                                            case 2:
                                                speaking.text = "KERA PES";
                                                display.text = "Get rid of whatever you put in the Rushing Worm.";
                                                break;
                                            case 3:
                                                display.text = "If you don't, I'll come back with reinforcements.";
                                                break;
                                            case 4:
                                                speaking.text = "FLARE";
                                                display.text = "... Alright. Have it your way.";
                                                break;
                                            default:
                                                box.SetActive(false);
                                                progressor.SetDialogue(false);
                                                break;
                                        }
                                    }
                                    break;
                                case 7:
                                    switch (toShow)
                                    {
                                        case 0:
                                            speaking.text = "SPECSHOT";
                                            display.text = "Please stop. You won, fair and square.";
                                            break;
                                        case 1:
                                            display.text = "Bullet Charm fights are supposed to be nonfatal.";
                                            break;
                                        case 2:
                                            speaking.text = "KERA PES";
                                            display.text = "And you know that how?";
                                            break;
                                        case 3:
                                            speaking.text = "SPECSHOT";
                                            display.text = "The first Sixwings made them to be a form of expression.";
                                            break;
                                        case 4:
                                            display.text = "Fighting with them used to be more like dancing.";
                                            break;
                                        case 5:
                                            display.text = "... You need to leave.";
                                            break;
                                        default:
                                            box.SetActive(false);
                                            progressor.SetDialogue(false);
                                            break;
                                    }*/
                                    break;
                                default:
                                    box.SetActive(false);
                                    progressor.SetDialogue(false);
                                    break;
                            }
                            break;
                        default:
                            box.SetActive(false);
                            progressor.SetDialogue(false);
                            break;
                    }
                    break;
                default:
                    box.SetActive(false);
                    progressor.SetDialogue(false);
                    break;
            }
        }
    }

    public void RunDialogue(int boss, int set)
    {
        box.SetActive(true);

        this.boss = boss;
        this.set = set;
        toShow = 0;

        progressor.SetDialogue(true);
    }
}
