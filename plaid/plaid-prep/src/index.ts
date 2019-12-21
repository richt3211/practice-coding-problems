class Node {
    val: number;
    left: Node | null = null;
    right: Node | null = null;
    constructor(val:number) {
        this.val = val;
    }
}

const isValidBst = (root:Node | null): boolean   => {
    // need to check recursively whether or not the tree to left and right are valid bst
    if (root === null) {
        return true;
    }
    const leftValid:boolean = isValidBstR(root.left, root.val, root.val, "left", "left");
    const rightValid:boolean = isValidBstR(root.right, root.val, root.val, "right", "right");
    return leftValid && rightValid;
}

const isValidBstR = (root:Node | null, currentVal:number, rootVal:number, dir:string, half:string):boolean => {
    if (root === null) {
        return true;
    }
    if (dir === "left") {
        if (root.val >= currentVal) {
            return false;
        }
    }
    else if (dir === "right") {
        if (root.val <= currentVal) {
            return false;
        }
    }
    if (half === "right") {
        if (root.val <= rootVal) 
            return false;
    }
    else if (half === "left") {
        if (root.val >= rootVal) {
            return false;
        }
    }
    const leftValid:boolean = isValidBstR(root.left, root.val, rootVal, "left", half);
    const rightValid:boolean = isValidBstR(root.right, root.val, rootVal,  "right", half);
    return leftValid && rightValid;
}

const test1 = () => {
    const root = new Node(2);
    root.left = new Node(1);
    root.right = new Node(3);
    console.log(isValidBst(root));
}

const test2 = () => {
    const root = new Node(10);
    root.left = new Node(5);
    root.left.left =  null;
    root.left.right = null;

    root.right = new Node(15);
    root.right.left = new Node(6);
    root.right.right = new Node(20);

    console.log(isValidBst(root));
}


test1()
test2()