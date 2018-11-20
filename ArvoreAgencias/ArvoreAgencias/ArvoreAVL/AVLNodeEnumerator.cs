using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
	public sealed class AvlNodeEnumerator<@int, @string> : IEnumerator<AvlNode<int, string>>
	{
		private AvlNode<int, string> _root;
		private Action _action;
		private AvlNode<int, string> _current;
		private AvlNode<int, string> _right;

		public AvlNodeEnumerator(AvlNode<int, string> root)
		{
			_right = _root = root;
			_action = _root == null ? Action.End : Action.Right;
		}

		public bool MoveNext()
		{
			switch (_action)
			{
				case Action.Right:
					_current = _right;

					while (_current.Left != null) _current = _current.Left;

					_right = _current.Right;
					_action = _right != null ? Action.Right : Action.Parent;
					return true;

				case Action.Parent:
					while (_current.Parent != null)
					{
						AvlNode<int, string> previous = _current;
						_current = _current.Parent;

						if (_current.Left == previous)
						{
							_right = _current.Right;
							_action = _right != null ? Action.Right : Action.Parent;
							return true;
						}
					}
					_action = Action.End;
					return false;

				default: return false;
			}
		}

		public void Reset()
		{
			_right = _root;
			_action = _root == null ? Action.End : Action.Right;
		}

		public AvlNode<int, string> Current
		{
			get {return _current;}
		}

		object IEnumerator.Current
		{
			get {return Current;}
		}

		public void Dispose() {}

		enum Action
		{
			Parent,
			Right,
			End
		}
	}
}