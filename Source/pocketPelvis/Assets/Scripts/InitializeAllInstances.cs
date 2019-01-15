using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class InitializeAllInstances : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ParserForAll stubbbbbbb = ParserForAll.Instance;
        EventManager stub = EventManager.Instance;
        StructureManager stubb = StructureManager.Instance;
        StructureFactory stubbb = StructureFactory.Instance;
        InteractionPanelFactory stubbbb = InteractionPanelFactory.Instance;
        InteractionPanelManager stubbbbb = InteractionPanelManager.Instance;
        InteractionGroupSorter stubbbbbb = InteractionGroupSorter.Instance;
        InteractionTypeName stubstub = InteractionTypeName.Instance;
        AudioInfoStructureNameManager stubstubstub = AudioInfoStructureNameManager.Instance;
        InteractionSearchHandler stubby = InteractionSearchHandler.Instance;
        AudioHandler stubbyy = AudioHandler.Instance;
        AudioSFXManager stubbss = AudioSFXManager.Instance;

        EventManager.Instance.publishStateEvent("All", "HIDE");
        //EventManager.Instance.publishStateEvent("All", "DEFAULT");


        //this is for if interactiontoggle is disabled, interactiontypename is disabled, colliders in modelbehaviour is disabled, and in parser you want gazelight and search to be off and only the first interaction groupings to be on
        /*
        OrderedDictionary interactionAndGroupings = ParserForAll.Instance.SortGroupsByInteractionTypes_ordered;
        IDictionaryEnumerator interactionAndGroupingsEnumerator = interactionAndGroupings.GetEnumerator();

        if (interactionAndGroupingsEnumerator.MoveNext() == false)
        {
            interactionAndGroupingsEnumerator.Reset();
            interactionAndGroupingsEnumerator.MoveNext();
        }
        
        if (interactionAndGroupingsEnumerator.MoveNext() == false)
        {
            interactionAndGroupingsEnumerator.Reset();
            interactionAndGroupingsEnumerator.MoveNext();
        }

        string currentInteraction = (string)interactionAndGroupingsEnumerator.Key;
        List<string> currentGroupings = (List<string>)interactionAndGroupingsEnumerator.Value;

        EventManager.Instance.publishInteractionEvent(currentInteraction, currentGroupings);
        */
    }
}
