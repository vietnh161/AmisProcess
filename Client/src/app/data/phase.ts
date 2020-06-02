import { Phase } from '../_models';

export var phaseData: Phase[] = [
    {
        id: 1,
        serial: 1,
        name: 'Khởi tạo',
        description: 'Phần này hiển thị mô tả',
        canDel:false,
        timeImplementType:'h',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [],
        processId: 1,
        fields: [
            {
                id: 1,
                name: 'Ngày bắt đầu',
                description: '',
                type: 'Date',
                required: true,
                pharseId: 2,
                
            },
            {
                id: 2,
                name: 'Ngày kết thúc',
                description: '',
                type: 'Date',
                required: true,
                pharseId: 2,
                
            }
        ],
    },
    {
        id: 2,
        serial: 4,
        name: 'Hoàn thành',
        description: 'Phần này hiển thị mô tả',
        canDel:false,
        timeImplementType:'h',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [
           
        ],
        fields: [
            
        ],
        processId: 1,

    },
    {
        id: 3,
        serial: 2,
        name: 'Quản lý phê duyệt',
        description: 'Phần này hiển thị mô tả',
        canDel:true,
        timeImplementType:'d',
        timeImplement: 3,
        personImplementType:'limit',
        personImplement: [
            {
                id: 1,
                employeeCode:'1',
                firstName: 'Quang',
                lastName: 'Lê Thanh',
        
            },
            {
                id: 2,
                employeeCode:'2',
                firstName: 'Hà',
                lastName: 'Hồ Quang',
            },
            {
                id: 3,
                employeeCode:'3',
                firstName: 'Bảo',
                lastName: 'Lê Ngọc',
            },
        ],
        fields: [

        ],
        processId: 1,

    },
    {
        id: 4,
        serial: 3,
        name: 'Giám đốc phê duyệt',
        description: 'Phần này hiển thị mô tả',
        canDel:true,
        timeImplementType:'m',
        timeImplement: 3,
        personImplementType:'all',
        personImplement: [

        ],
        fields: [
            
        ],
        processId: 1,

    },
     
]