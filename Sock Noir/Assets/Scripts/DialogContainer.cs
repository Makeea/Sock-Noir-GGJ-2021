using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContainer : MonoBehaviour
{
    public static List<Dialog> dialogs = new List<Dialog>{
        new Dialog{
            name = "Lacey",
            sentences = new string[]{
                "Hey, Looks like you're lost. Do you know where you are?",
                "Hmm. You must be new. You’re in the 'Downstairs'",
                "What? The Downstairs! You’ve never heard of it? I sometimes see you fancy closet & drawer dwellers visit from time to time.",
                "Shh! Stop interrupting! Now, what do you want?",
                "You're looking for your sock-mate? Her name is Kaki? She's the love of your life and you think she might be in danger?! Do you know what she looks like?",
                "Well, I haven’t seen anything since the dust-up a few hours ago. But you could try beyond yonder. But you better be careful! Closet-dweller’s like your kind go in, but they don’t come out! There are mysterious goings-on there! But go on - if you must!"
            }
        }
    };
    // public TextAsset json;
    void Start()
    {
        // dialogs = JsonUtility.FromJson<List<Dialog>>(json.text);
    }
}
