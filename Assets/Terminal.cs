using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public string currCommand;
    public TMP_Text commandPrompt;
    public TMP_Text fullField;

    public List<string> commands;

    public List<string> availableCommands;
    public List<string> stdCommands;
    public GameObject canvas;
    private void Start()
    {
        availableCommands = stdCommands;
    }
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (currCommand.Length != 0)
                {
                    currCommand = currCommand.Substring(0, currCommand.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                commands.Add(currCommand);
                Interpritator(currCommand.ToLower());
                currCommand = "";
            }
            else
            {
                currCommand += c;
            }
        }

        commandPrompt.text = currCommand.ToLower() + "_";
    }

    public void Interpritator(string command)
    {
        fullField.text += "<color=#878787>" + command + "<color=#00FF36>\n";
        if (command.Contains("xuy") || command.Contains("хуй") || command.Contains("blyad") || command.Contains("бляд") || command.Contains("чмо") || command.Contains("chmo") || command.Contains("idi na xuy") || command.Contains("huy") || command.Contains("hui") || command.Contains("bled") || command.Contains("poshel") || command.Contains("пошел") || command.Contains("ebal") || command.Contains("fuck") || command.Contains("slave") || command.Contains("cum"))
        {
            fullField.text += "Иди нахуй тварь ёбаная!!!! Играй в игру а не пиши эту хуйню!!!\n";
        }
        if (command == "exit")
        {
            canvas.SetActive(false);
            return;
        }
        if (command == "clear")
        {
            fullField.text = "help - available commands\n";
            return;
        }
        if (command == "help")
        {
            fullField.text += "Available commands: \n" + string.Join("\n", availableCommands.ToArray()) + "\nexit\nhelp\nclear\n^command - system tags, not called\n";
            return;
        }
        if (command == "back")
        {
            availableCommands = stdCommands;
            return;
        }
        if (command == "sell_cargo" && availableCommands.Contains(command))
        {
            var s = FindObjectOfType<Ship>();
            fullField.text += "Select resource: " + $"Iron [{s.iron}]\n" + $"Copper [{s.copper}]\n" + $"Diamonds [{s.diamond}]\n" + $"Rock [{s.rock}]\n[Stirng] [Int32] - [Mat. Name] [Value]\n";
            availableCommands = new List<string>() { "sell_cargo", "iron", "copper", "diamonds", "rock", "back", "^sell" };
        }
        if ((command.Contains("iron") || command.Contains("copper") || command.Contains("diamonds") || command.Contains("rock")))
        {
            if (availableCommands.Contains("^sell"))
            {
                var s = FindObjectOfType<Ship>();
                string fist = command.Split(' ')[0];
                int sec = 0;

                if (int.TryParse(command.Split(' ')[1], out sec))
                {
                    bool err = false; ;
                    switch (fist)
                    {
                        case "iron":
                            if (sec <= s.iron)
                            {
                                s.money += sec * FindObjectOfType<BaseStats>().ironcost;
                                s.iron -= sec;
                            }
                            else
                            {
                                err = true;
                            }
                            break;
                        case "copper":
                            if (sec <= s.copper)
                            {
                                s.money += sec * FindObjectOfType<BaseStats>().coppercost;
                                s.copper -= sec;
                            }
                            else
                            {
                                err = true;
                            }
                            break;
                        case "diamonds":
                            if (sec <= s.diamond)
                            {
                                s.money += sec * FindObjectOfType<BaseStats>().diamondscost;
                                s.diamond -= sec;
                            }
                            else
                            {
                                err = true;
                            }
                            break;
                        case "rock":
                            if (sec <= s.rock)
                            {
                                s.money += sec * FindObjectOfType<BaseStats>().rockcost;
                                s.rock -= sec;
                            }
                            else
                            {
                                err = true;
                            }
                            break;
                        default:
                            fullField.text += "The terminal cannot find such an object. Error [String]. \n";
                            break;
                    }
                    if (err) fullField.text += "Overflow of objects. Apparently you don't have that many [Int32]. \n"; else
                        fullField.text += "The transaction was successful. Your balance: " + s.money.ToString("F6") + ".\n";
                }
                else
                {
                    fullField.text += "Syntax error: [Int32] \n";
                }
            }
        }
        if (command == "get_user_id_stats" && availableCommands.Contains(command))
        {
            var s = FindObjectOfType<Ship>();
            fullField.text += "Stats: \n" + "User name: " + s.userName + "\nShip: " + s.ship + "\nMax Cargo: " + s.maxCargo + "\nMoney: " + s.money.ToString("F6") + "\n";
            availableCommands = new List<string>() { "set_user_name", "set_user_name_help", "get_base_prices", "back", "^user" };
        }

        if (command.Contains("set_user_name") && availableCommands.Contains("^user"))
        {
            if (command.Split(' ')[0] == "set_user_name")
            {
                try
                {
                    if (command.Split(' ')[1].Replace(" ", "") != "")
                    {
                        FindObjectOfType<Ship>().userName = command.Split(' ')[1].Replace(" ", "");
                        fullField.text += "Name delivered successfully. Your name: " + FindObjectOfType<Ship>().userName + ".\n";
                    }
                }
                catch (System.Exception)
                {
                    fullField.text += "The error is missing second argument [String] or another error.\n";
                }
                    
            }
        }
        if (command == "set_user_name_help" && availableCommands.Contains(command))
        {
            fullField.text += "[String] [String] - [set_user_name] - [user_name]\n";
        }
        if (command == "get_base_prices" && availableCommands.Contains(command))
        {
            var s = FindObjectOfType<BaseStats>();
            fullField.text += "Resources: \n\n" + $"Iron [{s.ironcost}]\n" + $"Copper [{s.coppercost}]\n" + $"Diamonds [{s.diamondscost}]\n" + $"Rock [{s.rockcost}]\n\n" +
                $"Price factor: " + s.cost.ToString("F6") + "\n";
        }
        if (command.Contains("transport_item_quest_sell") && availableCommands.Contains("^main"))
        {
            string[] parts = command.Split(' ');
            print(parts.Count());
            if (parts.Count() != 2)
            {
                fullField.text += "[String] [String] - Error\n";
                return;
            }

            Quest quest = FindObjectOfType<Quest>();
            for (int i = 0; i < quest.quests.Count; i++)
            {
                if (quest.quests[i].itemname.name != "")
                {
                    print("!= null");
                    if (quest.quests[i].itemname.name.ToLower() == parts[1].ToLower())
                    {
                        quest.quests[i].itemname.name = "";
                        fullField.text += "Moved\n";
                    }
                }
            }
        }
        if (command == "transport_item_quest_help" && availableCommands.Contains(command))
        {
            fullField.text += "[String] [String] - [transport_item_quest] [item_name]\n" +
                "Available: \n";

            Quest quest = FindObjectOfType<Quest>();
            for (int i = 0; i < quest.quests.Count; i++)
            {
                if (quest.quests[i].transport)
                {
                    if (quest.quests[i].itemname.name != "")
                    {
                        fullField.text += quest.quests[i].itemname.name + " to " + quest.quests[i].basename + "\n";
                    }
                }
            }
            fullField.text += "Current base: " + PlayerPrefs.GetString("BaseName", "Error") + "\n";
        }
        
    }
}
