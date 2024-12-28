<h1 align="center"> Cơ Sở Dữ Liệu Phân Tán <br/>
 Đề tài: Quản Lý Vật Tư
<h1>


# [**Publication and Subcription**](#publication-and-subcription)
  Với đề tài này chúng ta cần 2 server phân mảnh đề làm việc.
 
  Đối với phân mảnh 1 và 2: các bạn chọn hết tất cả các bảng trừ bảng sysdiagram(dbo)
 
 
![image](https://github.com/user-attachments/assets/19979fb7-f06a-4d46-a6d9-c6bc9508075e)


# [**Link Server**](#link-server)
   Theo đề tài này chúng ta có 3 server phân mảnh:
  
   Server 1 và server 2 chứa thông tin của chi nhánh 1 và chi nhánh 2. 
 
   Có 2 LINK cho mỗi server phân mảnh 1 & 2 như sau
 
    LINK0 đi từ phân mảnh này tới phân mảnh gốc
    LINK1 đi từ phân mảnh này tới phân mảnh còn lại
	  
  # [**Authorization**](#authorization)
   Đối với phân quyền, chúng ta sẽ cùng nhau phân tích đề bài:
   > Phân quyền: Chương trình có 3 nhóm : Công ty , ChiNhanh, User
   > -  Nếu login thuộc nhóm CongTy thì login đó có thể đăng nhập vào bất kỳ chi nhánh nào để xem số liệu bằng cách chọn tên chi nhánh, và chỉ có các chức năng sau:
![image](https://github.com/user-attachments/assets/67e8bc9b-045c-4517-af59-14f59c751b7b)
![image](https://github.com/user-attachments/assets/cf652c96-ee93-4224-9bbe-9445dbead8ea)


   >1.Chỉ có thể xem dữ liệu của phân mảnh tương ứng.
 
   >2.Xem được các báo cáo. (cấp quyền để gọi SP)
 ![image](https://github.com/user-attachments/assets/2ff4d4da-c339-41b8-86ee-41c139ed4ec2)


   >3.Tạo login thuộc nhóm Congty (chọn security admin trong login) - (thực hiện trên ứng dụng)
 
 
   >-  Nếu login thuộc nhóm ChiNhanh thì chỉ cho phép toàn quyền làm việc trên chi nhánh đó , không được log vào chi nhánh khác ; Tạo login thuộc nhóm ChiNhanh, User . (việc tạo login tương tự với nhóm CONGTY)
![image](https://github.com/user-attachments/assets/fa1603fe-87b4-419d-a27e-4411f2ec34d3)

   >- Nếu login thuộc nhóm User thì chỉ được quyền cập nhật dữ liệu, không được tạo tài khoản mới cho hệ thống. - (Không chọn security admin trong Login)
![image](https://github.com/user-attachments/assets/5cefd194-ab02-4d04-a670-5cb2389a1c52)
![image](https://github.com/user-attachments/assets/6e19fb46-3009-47ca-8563-86651d606aa5)


Chương trình cho phép ta tạo các login, password và cho login này làm việc với quyền hạn gì. Căn cứ vào quyền này khi user login vào hệ thống, ta sẽ biết người đó được quyền làm việc với mảnh phân tán nào hay trên tất cả các phân mảnh. 

  Công Ty có thể chuyển qua lại giữa các chi nhánh để xem dữ liệu nhưng không thể thêm - xóa - sửa, có thể tạo tài khoản với cùng vai trò Công ty. (Data reader)
 
  Chi nhánh không thể chuyển qua lại giữa các chi nhánh để xem dữ liệu nhưng có thể thêm - xóa - sửa thoải mái với phân mảnh đang đăng nhập, có thể tạo tài khoản với vai trò Chi nhánh hoặc User.
 
  User cũng không thể chuyển qua lại giữa các chi nhánh để xem dữ liệu nhưng có thể thêm - xóa - sửa thoải mái với phân mảnh đang đăng nhập, không thể tạo tài khoản.
 
