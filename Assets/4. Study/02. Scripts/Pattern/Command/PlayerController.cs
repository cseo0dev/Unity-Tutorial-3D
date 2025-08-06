using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController : MonoBehaviour
    {
        public Player player;

        private ICommand attackCommand, jumpCommand, skillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> executeCommands = new Stack<ICommand>();

        void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "Fireball");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)) // ���� ���
            {
                attackCommand.Execute();
                executeCommands.Push(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.W)) // ���� ���
            {
                jumpCommand.Execute();
                executeCommands.Push(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E)) // ��ų ���
            {
                skillCommand.Execute();
                executeCommands.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� ���
            {
                commandQueue.Enqueue(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) // ���� ���
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) // ��ų ���
            {
                commandQueue.Enqueue(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�� ���� �� ��� ����");

                while (commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                    executeCommands.Push(command);
                }
            }

            if (Input.GetKeyDown(KeyCode.Z)) // ��� ���
            {
                if (executeCommands.Count > 0)
                {
                    ICommand lastCommand = executeCommands.Pop(); // ���� �ֱٿ� ������ ���
                    Debug.Log($"��� ��� : {lastCommand.GetType().Name}");

                    lastCommand.Cancel(); // Undo
                }
                else
                {
                    Debug.Log("�ǵ��� ����� �����ϴ�.");
                }
            }
        }
    }
}