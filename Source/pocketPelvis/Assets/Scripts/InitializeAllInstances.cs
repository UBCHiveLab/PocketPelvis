using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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
        //InteractionTypeName stubstub = InteractionTypeName.Instance;
        AudioInfoStructureNameManager stubstubstub = AudioInfoStructureNameManager.Instance;
        //InteractionSearchHandler stubby = InteractionSearchHandler.Instance;
        AudioHandler stubbyy = AudioHandler.Instance;
        AudioSFXManager stubbss = AudioSFXManager.Instance;

        EventManager.Instance.publishStateEvent("All", "HIDE");
        //EventManager.Instance.publishStateEvent("All", "DEFAULT");

        // for if toggle is off
        EventManager.Instance.publishInteractionEvent("Structure Groups");
    }
}
