
using System.Collections;
using System.Collections.Generic;

namespace AVLTree 
{
    public class AvlTree<@int, @string> : IEnumerable<AvlNode<int, string>>
	{
		private IComparer<int> _comparer;
		private AvlNode<int, string> _root;

		public AvlTree(IComparer<int> comparer){_comparer = comparer;}

		public AvlTree() : this(Comparer<int>.Default){}

		public AvlNode<int, string> Root
		{
			get {return _root;}
		}

		public IEnumerator<AvlNode<int, string>> GetEnumerator()
		{
			return new AvlNodeEnumerator<int, string>(_root);
		}

		public AvlNode<int, string> Search(int key)
		{
			AvlNode<int, string> node = _root;

			while (node != null)
			{
                if (_comparer.Compare(key, node.Key) == 0) return node;
				if (_comparer.Compare(key, node.Key) < 0) node = node.Left;
				else if (_comparer.Compare(key, node.Key) > 0) node = node.Right;
			}
            return null;
		} //search

		public bool Insert(int key, string value)
		{
			AvlNode<int, string> node = _root;

			while (node != null)
			{
				int compare = _comparer.Compare(key, node.Key);

				if (compare < 0)
				{
					AvlNode<int, string> left = node.Left;

					if (left == null)
					{
						node.Left = new AvlNode<int, string> { Key = key, Value = value, Parent = node };
						InsertBalance(node, 1);
						return true;
					}
					else node = left;
				}
				else if (compare > 0)
				{
					AvlNode<int, string> right = node.Right;

					if (right == null)
					{
						node.Right = new AvlNode<int, string> { Key = key, Value = value, Parent = node };
						InsertBalance(node, -1);
						return true;
					}
					else node = right;
				}
				else
				{
					node.Value = value;
					return false;
				}
			} //while
			
			_root = new AvlNode<int, string> { Key = key, Value = value };
			return true;
		} //insert

		private void InsertBalance(AvlNode<int, string> node, int balance)
		{
			while (node != null)
			{
				balance = (node.Balance += balance);

				if (balance == 0) return;
				else if (balance == 2)
				{
					if (node.Left.Balance == 1) RotateRight(node);
					else RotateLeftRight(node);
					return;
				}
				else if (balance == -2)
				{
					if (node.Right.Balance == -1) RotateLeft(node);
					else RotateRightLeft(node);
					return;
				}

				AvlNode<int, string> parent = node.Parent;

				if (parent != null) balance = parent.Left == node ? 1 : -1;
				node = parent;
			} //while
		} //insertBalance

		private AvlNode<int, string> RotateLeft(AvlNode<int, string> node)
		{
			AvlNode<int, string> right = node.Right;
			AvlNode<int, string> rightLeft = right.Left;
			AvlNode<int, string> parent = node.Parent;

			right.Parent = parent;
			right.Left = node;
			node.Right = rightLeft;
			node.Parent = right;

			if (rightLeft != null) rightLeft.Parent = node;

			if (node == _root) _root = right;
			else if (parent.Right == node) parent.Right = right;
			else parent.Left = right;

			right.Balance++;
			node.Balance = -right.Balance;
			return right;
		} //rotateLeft

		private AvlNode<int, string> RotateRight(AvlNode<int, string> node)
		{
			AvlNode<int, string> left = node.Left;
			AvlNode<int, string> leftRight = left.Right;
			AvlNode<int, string> parent = node.Parent;

			left.Parent = parent;
			left.Right = node;
			node.Left = leftRight;
			node.Parent = left;

			if (leftRight != null) leftRight.Parent = node;

			if (node == _root) _root = left;
			else if (parent.Left == node) parent.Left = left;
			else parent.Right = left;

			left.Balance--;
			node.Balance = -left.Balance;
			return left;
		} //rotateRight

		private AvlNode<int, string> RotateLeftRight(AvlNode<int, string> node)
		{
			AvlNode<int, string> left = node.Left;
			AvlNode<int, string> leftRight = left.Right;
			AvlNode<int, string> parent = node.Parent;
			AvlNode<int, string> leftRightRight = leftRight.Right;
			AvlNode<int, string> leftRightLeft = leftRight.Left;

			leftRight.Parent = parent;
			node.Left = leftRightRight;
			left.Right = leftRightLeft;
			leftRight.Left = left;
			leftRight.Right = node;
			left.Parent = leftRight;
			node.Parent = leftRight;

			if (leftRightRight != null) leftRightRight.Parent = node;

			if (leftRightLeft != null) leftRightLeft.Parent = left;

			if (node == _root) _root = leftRight;
			else if (parent.Left == node) parent.Left = leftRight;
			else parent.Right = leftRight;

			if (leftRight.Balance == -1)
			{
				node.Balance = 0;
				left.Balance = 1;
			}
			else if (leftRight.Balance == 0)
			{
				node.Balance = 0;
				left.Balance = 0;
			}
			else
			{
				node.Balance = -1;
				left.Balance = 0;
			}

			leftRight.Balance = 0;
			return leftRight;
		} //rotateLeftRight

		private AvlNode<int, string> RotateRightLeft(AvlNode<int, string> node)
		{
			AvlNode<int, string> right = node.Right;
			AvlNode<int, string> rightLeft = right.Left;
			AvlNode<int, string> parent = node.Parent;
			AvlNode<int, string> rightLeftLeft = rightLeft.Left;
			AvlNode<int, string> rightLeftRight = rightLeft.Right;

			rightLeft.Parent = parent;
			node.Right = rightLeftLeft;
			right.Left = rightLeftRight;
			rightLeft.Right = right;
			rightLeft.Left = node;
			right.Parent = rightLeft;
			node.Parent = rightLeft;

			if (rightLeftLeft != null) rightLeftLeft.Parent = node;

			if (rightLeftRight != null) rightLeftRight.Parent = right;

			if (node == _root) _root = rightLeft;
			else if (parent.Right == node) parent.Right = rightLeft;
			else parent.Left = rightLeft;

			if (rightLeft.Balance == 1)
			{
				node.Balance = 0;
				right.Balance = -1;
			}
			else if (rightLeft.Balance == 0)
			{
				node.Balance = 0;
				right.Balance = 0;
			}
			else
			{
				node.Balance = 1;
				right.Balance = 0;
			}

			rightLeft.Balance = 0;
			return rightLeft;
		} //rotateRightLeft

		public bool Delete(int key)
		{
			AvlNode<int, string> node = _root;

			while (node != null)
			{
				if (_comparer.Compare(key, node.Key) < 0) node = node.Left;
				else if (_comparer.Compare(key, node.Key) > 0) node = node.Right;
				else
				{
					AvlNode<int, string> left = node.Left;
					AvlNode<int, string> right = node.Right;

					if (left == null)
					{
						if (right == null)
						{
							if (node == _root) _root = null;
							else
							{
								AvlNode<int, string> parent = node.Parent;

								if (parent.Left == node)
								{
									parent.Left = null;
									DeleteBalance(parent, -1);
								}
								else
								{
									parent.Right = null;
									DeleteBalance(parent, 1);
								}
							}
						}
						else
						{
							Replace(node, right);
							DeleteBalance(node, 0);
						}
					}
					else if (right == null)
					{
						Replace(node, left);
						DeleteBalance(node, 0);
					}
					else
					{
						AvlNode<int, string> successor = right;

						if (successor.Left == null)
						{
							AvlNode<int, string> parent = node.Parent;

							successor.Parent = parent;
							successor.Left = left;
							successor.Balance = node.Balance;
							left.Parent = successor;

							if (node == _root) _root = successor;
							else
							{
								if (parent.Left == node) parent.Left = successor;
								else parent.Right = successor;
							}

							DeleteBalance(successor, 1);
						}
						else
						{
							while (successor.Left != null) successor = successor.Left;

							AvlNode<int, string> parent = node.Parent;
							AvlNode<int, string> successorParent = successor.Parent;
							AvlNode<int, string> successorRight = successor.Right;

							if (successorParent.Left == successor) successorParent.Left = successorRight;
							else successorParent.Right = successorRight;

							if (successorRight != null) successorRight.Parent = successorParent;

							successor.Parent = parent;
							successor.Left = left;
							successor.Balance = node.Balance;
							successor.Right = right;
							right.Parent = successor;
							left.Parent = successor;

							if (node == _root) _root = successor;
							else
							{
								if (parent.Left == node) parent.Left = successor;
								else parent.Right = successor;
							}

							DeleteBalance(successorParent, -1);
						}
					}
					return true;
				} //else
			} //while
			return false;
		} //delete

		private void DeleteBalance(AvlNode<int, string> node, int balance)
		{
			while (node != null)
			{
				balance = (node.Balance += balance);

				if (balance == 2)
				{
					if (node.Left.Balance >= 0)
					{
						node = RotateRight(node);
						if (node.Balance == -1) return;
					}
					else node = RotateLeftRight(node);
				}
				else if (balance == -2)
				{
					if (node.Right.Balance <= 0)
					{
						node = RotateLeft(node);
						if (node.Balance == 1) return;
					}
					else node = RotateRightLeft(node);
				}
				else if (balance != 0) return;

				AvlNode<int, string> parent = node.Parent;

				if (parent != null) balance = parent.Left == node ? -1 : 1;
				node = parent;
			} //while
		} //deleteBalance

		private static void Replace(AvlNode<int, string> target, AvlNode<int, string> source)
		{
			AvlNode<int, string> left = source.Left;
			AvlNode<int, string> right = source.Right;

			target.Balance = source.Balance;
			target.Key = source.Key;
			target.Value = source.Value;
			target.Left = left;
			target.Right = right;

			if (left != null) left.Parent = target;
			if (right != null) right.Parent = target;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}