using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using cakeslice;

public class BasicStructure
{
    //Correct behaviour only works with objects attached to specific types of shader. Doesn't work with default shaders.

    GameObject structure;
    Renderer thisRenderer;
    Color normalColor;
    Color highlightedColor;

    //enum STATE { DEFAULT, HIGHLIGHT, FADE, HIDE, ISOLATE };
    enum STATE { DEFAULT, HIDE};
    STATE state;
    enum INFO { DEFAULT, DESCRIPTION, FUNCTION, INNERVATION };
    INFO info;

    public BasicStructure(string name)
    {
        structure = GameObject.Find(name);
        //check for if structure in .txt list exist in game or not
        if (structure != null)
        {
            thisRenderer = structure.gameObject.GetComponent<Renderer>();
            instantiateColor(2f);

            state = STATE.DEFAULT;
            info = INFO.DEFAULT;

            EventManager.Instance.StateEvent += OnStateEvent;
            //EventManager.Instance.InfoEvent += OnInfoEvent;
        } else
        {
            Debug.Log("name is null: " + name + " , count is: " + name.Length);
        }
    }

    /*
    public void OnStateEvent(string wantedName, string wantedState)
    {
        if (checkForName(wantedName))
        {
            STATE currentState = state;
            if (wantedState != "")
            {
                currentState = getPrevState((STATE)Enum.Parse(typeof(STATE), wantedState));
            }
            switch (currentState)
            {
                case STATE.DEFAULT:
                    highlightState();
                    state = STATE.HIGHLIGHT;
                    break;
                case STATE.HIGHLIGHT:
                    fadeState();
                    state = STATE.FADE;
                    break;
                case STATE.FADE:
                    hideState();
                    state = STATE.HIDE;
                    break;
                case STATE.HIDE:
                    defaultState();
                    state = STATE.DEFAULT;
                    break;
            }
            EventManager.Instance.publishStateChangedEvent(structure.gameObject.name, Enum.GetName(typeof(STATE), state));
        }
    }
    */

    //this has only default and hide
    public void OnStateEvent(string wantedName, string wantedState)
    {
        if (checkForName(wantedName))
        {
            STATE currentState = state;
            if (wantedState != "")
            {
                currentState = getPrevState((STATE)Enum.Parse(typeof(STATE), wantedState));
            }
            switch (currentState)
            {
                case STATE.DEFAULT:
                    hideState();
                    state = STATE.HIDE;
                    break;
                case STATE.HIDE:
                    defaultState();
                    state = STATE.DEFAULT;
                    break;
            }
            EventManager.Instance.publishStateChangedEvent(structure.gameObject.name, Enum.GetName(typeof(STATE), state));
        }
    }

    public void OnInfoEvent(string name)
    {
        if (checkForName(name))
        {
            switch (info)
            {
                case INFO.DEFAULT:
                    descriptionInfo();
                    info = INFO.DESCRIPTION;
                    break;
                case INFO.DESCRIPTION:
                    functionInfo();
                    info = INFO.FUNCTION;
                    break;
                case INFO.FUNCTION:
                    innervationInfo();
                    info = INFO.INNERVATION;
                    break;
                case INFO.INNERVATION:
                    defaultInfo();
                    info = INFO.DEFAULT;
                    break;
            }
        }
    }

    protected void defaultState()
    {
        //Debug.Log("default state");
        thisRenderer.enabled = true;
        thisRenderer.material.SetFloat("_Transparency", .01f);
        thisRenderer.material.SetFloat("_Specular Intensity", .2f);
        thisRenderer.material.SetColor("_Color", normalColor);
    }

    protected void highlightState()
    {
        //Debug.Log("highlight state");
        thisRenderer.enabled = true;
        thisRenderer.material.SetFloat("_Transparency", 0f);
        thisRenderer.material.SetFloat("_Specular Intensity", 0f);
        thisRenderer.material.SetColor("_Color", highlightedColor);
    }

    protected void hideState()
    {
        //Debug.Log("hide state");
        thisRenderer.enabled = false;
        thisRenderer.material.SetFloat("_Transparency", 1f);
        thisRenderer.material.SetFloat("_Specular Intensity", .2f);
    }

    protected void fadeState()
    {
        //Debug.Log("fade state");
        thisRenderer.enabled = true;
        thisRenderer.material.SetFloat("_Transparency", .5f);
        thisRenderer.material.SetFloat("_Specular Intensity", .2f);
        thisRenderer.material.SetColor("_Color", normalColor);
    }

    //TODO: send info to structureinfomanager
    private void defaultInfo()
    {
        EventManager.Instance.publishInfoDisplayEvent(structure.gameObject.name, Enum.GetName(typeof(INFO), INFO.DEFAULT));
    }

    protected void descriptionInfo()
    {
        EventManager.Instance.publishInfoDisplayEvent(structure.gameObject.name, Enum.GetName(typeof(INFO), INFO.DESCRIPTION));
    }

    protected void functionInfo()
    {
        EventManager.Instance.publishInfoDisplayEvent(structure.gameObject.name, Enum.GetName(typeof(INFO), INFO.FUNCTION));
    }

    protected void innervationInfo()
    {
        EventManager.Instance.publishInfoDisplayEvent(structure.gameObject.name, Enum.GetName(typeof(INFO), INFO.INNERVATION));
    }

    public virtual bool checkForName(string name)
    {
        return name.Equals("") || name.Equals(structure.gameObject.name);
    }

    private void instantiateColor(float multiplier)
    {
        normalColor = thisRenderer.material.color;
        highlightedColor = new Color(increaseColor(normalColor.r, multiplier), increaseColor(normalColor.g, multiplier), increaseColor(normalColor.b, multiplier), normalColor.a);
    }

    private float increaseColor(float color, float multiplier)
    {
        float wanted = color * multiplier;
        if (wanted <= 1.0f)
        {
            return wanted;
        } else
        {
            return 1.0f;
        }
    }

    //return next state, or default
    /*
    private STATE getNextState(STATE s)
    {
        STATE state = STATE.DEFAULT;
        switch (s)
        {
            case STATE.DEFAULT:
                state = STATE.HIGHLIGHT;
                break;
            case STATE.HIGHLIGHT:
                state = STATE.FADE;
                break;
            case STATE.FADE:
                state = STATE.HIDE;
                break;
            case STATE.HIDE:
                state = STATE.DEFAULT;
                break;
        }
        return state;
    }
    */

    //return previous state, or default
    /*
    private STATE getPrevState(STATE s)
    {
        STATE state = STATE.DEFAULT;
        switch (s)
        {
            case STATE.FADE:
                state = STATE.HIGHLIGHT;
                break;
            case STATE.HIDE:
                state = STATE.FADE;
                break;
            case STATE.DEFAULT:
                state = STATE.HIDE;
                break;
            case STATE.HIGHLIGHT:
                state = STATE.DEFAULT;
                break;
        }
        return state;
    }
    */

    private STATE getPrevState(STATE s)
    {
        STATE state = STATE.DEFAULT;
        switch (s)
        {
            case STATE.HIDE:
                state = STATE.DEFAULT;
                break;
            case STATE.DEFAULT:
                state = STATE.HIDE;
                break;
        }
        return state;
    }
}